using UnityEngine;
using System.Collections;

public class LevelProgressPoint : ObjectEvent
{
    [SerializeField] private LevelProgressManager progressManager;
    [SerializeField] private bool progressCompleted;
    [SerializeField] private bool testButton = false;

    public bool ProgressCompleted
    {
        get { return progressCompleted; }
        set { progressCompleted = value; }
    }

    void Update()
    {
        if(testButton)
        {
            StartEvent(this.gameObject, this.gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
        progressManager = GameObject.FindGameObjectWithTag("manager").GetComponent<LevelProgressManager>();
	}

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        Debug.Log("threshold reached");
        base.StartEvent(thisObj, otherObj);
        if(!ProgressCompleted)
        {
            ProgressCompleted = true;
            progressManager.NewProgress();
        }
    }
}
