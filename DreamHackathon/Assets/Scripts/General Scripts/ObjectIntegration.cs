using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody))]
public class ObjectIntegration : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private ObjectEvent[] objEvents;
    [SerializeField] private bool findAllObjectsOfTypeInTargets = false;


    void Start()
    {
        if (findAllObjectsOfTypeInTargets)
        {
            foreach(GameObject GO in targets)
            {
                GameObject[] targetTag = GameObject.FindGameObjectsWithTag(GO.tag);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
        foreach (GameObject go in targets)
        {
            if (collision.gameObject == go)
            {
                Debug.Log("Is colliding with target");
                foreach (ObjectEvent objEvent in objEvents)
                {
                    objEvent.StartAction(this.gameObject, collision.gameObject);
                }
            }
        }
    }
}
