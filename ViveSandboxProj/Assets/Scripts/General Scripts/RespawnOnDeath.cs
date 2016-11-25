using UnityEngine;
using System.Collections;

public class RespawnOnDeath : OnDeathFunctions
{
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float cooldown;
    [SerializeField] private float timer;
    [SerializeField] private bool visiblity = true;

    void Start()
    {
        startingPos = this.transform.position;
    }

    void Update()
    {
        if (!visiblity)
        {
            visiblity = true;
            timer = cooldown;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }

    }

    public override void DestroyTask()
    {
        base.DestroyTask();
        this.transform.position = startingPos;
        visiblity = false;
    }


}
