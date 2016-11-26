using UnityEngine;
using System.Collections;

public class SpawnObjectEvent : ObjectEvent
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private bool useCooldown = false;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float timer;
    [SerializeField] private bool spawnStarted = false;

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);

        if(!spawnStarted)
        {
            spawnStarted = true;
            StartSpawning();
        }
    }

    void StartSpawning()
    {
        if(useCooldown)
        {
            timer = spawnCooldown;
            useCooldown = false;
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            Instantiate(objectToSpawn, spawnPos, transform.rotation);
        }
    }
}
