using UnityEngine;
using System.Collections;

public class AddDestroyOverTimeOnCollisionEvent : ObjectEvent
{
  
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        otherObj.AddComponent<DestroyOverTime>();
        otherObj.GetComponent<DestroyOverTime>().startCoolDown = true;
    }
}
