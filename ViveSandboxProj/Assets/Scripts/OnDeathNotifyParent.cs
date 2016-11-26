using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Destroy))]
public class OnDeathNotifyParent : OnDeathFunctions
{
    [SerializeField] private ObjRespawner parentObj;
    public override void DestroyTask()
    {
        base.DestroyTask();
        parentObj.ChildDied();
        Debug.Log("Notifying parent");
    }

    public void SetParent(GameObject parent)
    {
        parentObj = parent.GetComponent<ObjRespawner>();
        gameObject.GetComponent<Destroy>().AddToDeathFunctions(this);

    }
}
