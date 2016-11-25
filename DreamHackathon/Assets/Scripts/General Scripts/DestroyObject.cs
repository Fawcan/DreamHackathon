using UnityEngine;
using System.Collections;

public class DestroyObject : OnDeathFunctions {

    public override void DestroyTask()
    {
        base.DestroyTask();

        Destroy(gameObject);
    }
}
