using UnityEngine;
using System.Collections;

public class AddDestroyOverTimeOnCollisionEvent : ObjectEvent
{
  
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        otherObj.AddComponent<DestroyOverTime>();
        Debug.Log("Destroy over time added to: " + otherObj);
    }
}
