using UnityEngine;
using System.Collections;

public class OnDestory : MonoBehaviour {

    [SerializeField] private OnDeathFunctions[] deathFunctions;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void DestroyObject()
    {
        foreach (OnDeathFunctions function in deathFunctions)
        {
            //function.DestroyTask();
        }
    }
}
