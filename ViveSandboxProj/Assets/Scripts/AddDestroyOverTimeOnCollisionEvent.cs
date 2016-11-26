using UnityEngine;
using System.Collections;

public class AddDestroyOverTimeOnImpact : ObjectEvent
{
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        otherObj.AddComponent<DestroyOverTime>();
    }
}
