using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class ObjectIntegration : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private ObjectEvent[] objEvents;
    [SerializeField] private bool findAllObjectsOfTypeInTargets = false;
    [SerializeField] private bool eventTriggered = false;
    [SerializeField] private bool eventRepeatable = false;

    [SerializeField] private float eventCooldown = 0;
    private float timer = 0;


    void Start()
    {
        if (findAllObjectsOfTypeInTargets)
        {
            foreach (GameObject GO in targets)
            {
                
            }
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else if (timer <= 0)
        {
            eventTriggered = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
        if (!eventTriggered)
        {
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

            if (eventRepeatable)
            {
                if (eventCooldown == 0)
                    Debug.Log("Cooldown is Zero, please insert value in the Inspector");

                timer = eventCooldown;
            }
        }
    }
}
