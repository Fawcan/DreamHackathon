using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelProgressManager : MonoBehaviour
{
    [Tooltip("List holding all the conditions needed to open door, to add to list during runtime call AddProgressPoint()")]
    [SerializeField] private List<LevelProgressPoint> progressPoints = new List<LevelProgressPoint>();
    [Tooltip("Returns the progress in a float between 0 and 1")]
    [SerializeField] private float progress;
    [SerializeField] private LEDBar ledBar;

    void Start()
    {
        ledBar = GameObject.FindGameObjectWithTag("floorBar").GetComponent<LEDBar>();
    }
    void Update()
    {
        ledBar.NormFillValue = progress;
    }
    public void NewProgress()
    {
        progress = 0;
        foreach (LevelProgressPoint progressPoint in progressPoints)
        {
            if(progressPoint.ProgressCompleted)
            {
                progress++;
            }
        }
        progress = progress / progressPoints.Count;
        Debug.Log(progress);
    }


    public void AddProgressPoint(LevelProgressPoint newPoint)
    {
        progressPoints.Add(newPoint);
    }
}
