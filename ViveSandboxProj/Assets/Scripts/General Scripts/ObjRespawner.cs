using UnityEngine;
using System.Collections;

public class ObjRespawner : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private GameObject currentObj;
    private Vector3 spawnPos;

    [SerializeField] private float respawnCooldown;
    [SerializeField] private bool childIsDead;
    [SerializeField] private float timer;

    public void ChildDied()
    {
        childIsDead = true;
        Debug.Log("Child died");

        if (respawnCooldown > 0)
        {
            timer = respawnCooldown;
        }


    }


    void Start()
    {
        
        this.GetComponentInChildren<Renderer>().enabled = false;
           spawnPos = transform.position;
        

        SpawnObj();
    }

    void SpawnObj()
    {
        Debug.Log("spawning obj");
        Instantiate(objToSpawn, spawnPos, this.transform.rotation);
        childIsDead = false;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objToSpawn.tag);

        foreach (GameObject obj in objs)
        {
            if(obj.transform.position == spawnPos)
            {
                currentObj = obj;
                currentObj.AddComponent<OnDeathNotifyParent>();
                currentObj.GetComponent<OnDeathNotifyParent>().SetParent(this.gameObject);

                break;
            }
        }
    }

    void Update()
    {
        if(childIsDead)
        {
            Debug.Log("Respawn timer has started");
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            else if (timer <= 0)
            {
                SpawnObj();
            }
        }
    }
}
