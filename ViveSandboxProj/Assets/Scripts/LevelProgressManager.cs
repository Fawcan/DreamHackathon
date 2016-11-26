using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelProgressManager : MonoBehaviour
{
    [Tooltip("List holding all the conditions needed to open door, to add to list during runtime call AddProgressPoint()")]
    [SerializeField] private List<LevelProgressPoint> progressPoints = new List<LevelProgressPoint>();
    [Tooltip("Returns the progress in a float between 0 and 1")]
    [SerializeField] private int pointsCompleted;
    [SerializeField] private float progress;
    [SerializeField] private LEDBar ledBar;
    [SerializeField] private ObjectEvent objEvent;
    [SerializeField] private GameObject objToDoStuffTo;
    [Tooltip("Used to define how many tasks need to be completed to start event")]
    [SerializeField] private int pointThreshold;
    private bool thresholdEventStarted = false;

    public int PointsCompleted
    {
        get { return pointsCompleted; }
    }

    void Start()
    {
        ledBar = GameObject.FindGameObjectWithTag("floorBar").GetComponent<LEDBar>();
    }
    void Update()
    {
        ledBar.NormFillValue = progress;

        if (pointThreshold <= pointsCompleted)
        {
            ProgressThreshold();
        }
    }
    public void NewProgress()
    {
        pointsCompleted = 0;
        foreach (LevelProgressPoint progressPoint in progressPoints)
        {
            if(progressPoint.ProgressCompleted)
            {
                pointsCompleted++;
            }
        }
        progress = pointsCompleted / progressPoints.Count;
        Debug.Log(progress);
    }


    public void AddProgressPoint(LevelProgressPoint newPoint)
    {
        progressPoints.Add(newPoint);
    }

    private void ProgressThreshold()
    {
        Debug.Log("Threshold reached");
        if(!thresholdEventStarted)
        {
            thresholdEventStarted = true;
            objEvent.StartEvent(this.gameObject, objToDoStuffTo);
            objEvent.enabled = false;
        }
    }
}
