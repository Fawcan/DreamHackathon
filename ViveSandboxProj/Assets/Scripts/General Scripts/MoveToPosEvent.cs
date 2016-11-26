using UnityEngine;
using System.Collections;

public class MoveToPosEvent : ObjectEvent
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float lerpTime;
    [SerializeField] private bool startLerp = false;
    [SerializeField] private bool lerpRunning = false;
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);
        startLerp = true;

        if (startLerp && !lerpRunning)
        {
            startingPos = this.transform.position;
        }
    }


    void Update()
    {
        if(startLerp || lerpRunning)
        {
            startLerp = false;
            lerpRunning = true;
            this.transform.position = Vector3.Lerp(startingPos, targetPos, lerpTime);
        }

        if(this.transform.position == targetPos)
        {
            lerpRunning = false;
        }
        
    }
}
