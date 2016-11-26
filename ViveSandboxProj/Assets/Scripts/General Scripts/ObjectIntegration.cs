using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class ObjectIntegration : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private ObjectEvent[] objEvents;
    [SerializeField] private bool findAllObjectsOfTypeInTargets = false;


    void Start()
    {
        if (findAllObjectsOfTypeInTargets)
        {
            foreach (GameObject GO in targets)
            {
                
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
                    objEvent.StartEvent(this.gameObject, collision.gameObject);
                }
            }
        }
    }
}
