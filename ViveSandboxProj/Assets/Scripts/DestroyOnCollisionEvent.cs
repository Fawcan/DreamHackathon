using UnityEngine;
using System.Collections;

public class DestroyOnCollisionEvent : ObjectEvent
{
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);
        Destroy(otherObj);
    }
}
