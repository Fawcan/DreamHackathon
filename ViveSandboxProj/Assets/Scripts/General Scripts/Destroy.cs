using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy : MonoBehaviour {

    [SerializeField] private List<OnDeathFunctions> deathFunctions = new List<OnDeathFunctions>();

	// Use this for initialization
	void Start ()
    {
        OnDeathFunctions[] functions = this.GetComponents<OnDeathFunctions>();
        foreach (OnDeathFunctions function in functions)
        {
            AddToDeathFunctions(function);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnDestroy()
    {
        foreach (OnDeathFunctions function in deathFunctions)
        {
            Debug.Log("Running destroy functions on " + this);
            function.DestroyTask();
        }
    }

    public void AddToDeathFunctions(OnDeathFunctions function)
    {
        deathFunctions.Add(function);
        Debug.Log("Added instance " + function);
    }
}
