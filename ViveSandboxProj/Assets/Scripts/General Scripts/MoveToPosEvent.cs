using UnityEngine;
using System.Collections;

public class MoveToPosEvent : ObjectEvent
{
    [Tooltip("Leave this at 0 if you dont want the object to move forward for the amount inputed")]
    [SerializeField] private float distanceToMove = 0;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float lerpTime;
    [SerializeField] private float currentLerpTime;
    [SerializeField] private bool isLerping = false;

    private float timeStartedLerping;
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);
        StartLerping();

       
    }

    private void StartLerping()
    {

        if (!isLerping)
        {
            Debug.Log("started lerping");
            isLerping = true;
            startingPos = this.transform.position;
            timeStartedLerping = Time.time;
            if (distanceToMove != 0)
            {
                targetPos = transform.position + Vector3.forward * distanceToMove;
            }
        }
    }

    void Update()
    {
        if(isLerping)
        {
            currentLerpTime += Time.deltaTime;
            if(currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float t = currentLerpTime / lerpTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            this.transform.position = Vector3.Lerp(startingPos, targetPos, t);

            if (t >= 1)
            {
                isLerping = false;
            }
        }

        
    }
}
