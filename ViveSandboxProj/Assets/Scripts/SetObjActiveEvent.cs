using UnityEngine;
using System.Collections;

public class SetObjActiveEvent : ObjectEvent
{
    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);
        otherObj.SetActive(true);
    }
}
