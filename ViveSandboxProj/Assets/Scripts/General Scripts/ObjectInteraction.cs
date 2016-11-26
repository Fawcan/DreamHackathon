using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent (typeof(Rigidbody))]
public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private List<ObjectEvent> objEvents = new List<ObjectEvent>();
    [SerializeField] private bool eventTriggered = false;
    [SerializeField] private bool eventRepeatable = false;

    [SerializeField] private float eventCooldown = 0;
    private float timer = 0;


    void Start()
    {
        ObjectEvent[] events = this.GetComponents<ObjectEvent>();
        foreach (ObjectEvent newEvent in events)
        {
            AddEvent(newEvent);
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

    public void AddEvent(ObjectEvent newEvent)
    {
        objEvents.Add(newEvent);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject + " is Colliding with " + collision.gameObject);
        if (!eventTriggered)
        {
            foreach (GameObject go in targets)
            {
                if (collision.gameObject.tag == go.tag)
                {
                    Debug.Log("Is colliding with target");
                    foreach (ObjectEvent objEvent in objEvents)
                    {
                        objEvent.StartEvent(this.gameObject, collision.gameObject);
                    }
                }
            }

            eventTriggered = true;

            if (eventRepeatable)
            {
                if (eventCooldown == 0)
                    Debug.Log("Cooldown is Zero, please insert value in the Inspector");

                timer = eventCooldown;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eventTriggered)
        {

            Debug.Log(this.gameObject + "s trigger was entererd by " + other);
            foreach (GameObject go in targets)
            {
                Debug.Log("checking targets");
                   
               
                foreach (ObjectEvent objEvent in objEvents)
                {
                    objEvent.StartEvent(this.gameObject, other.GetComponent<GameObject>());
                }
                
            }

            eventTriggered = true;

            if (eventRepeatable)
            {
                if (eventCooldown == 0)
                    Debug.Log("Cooldown is Zero, please insert value in the Inspector");

                timer = eventCooldown;
            }
        }
    }
}
