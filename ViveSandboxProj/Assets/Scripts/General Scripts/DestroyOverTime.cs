using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float cooldown = 2;
    [SerializeField] private float timer = 0;
    private bool countDownFinished = false;
    public bool startCoolDown;
    private bool cooldownStarted = false;

	// Update is called once per frame
    void Start()
    {
        
    }
	void Update ()
    {
        if(startCoolDown)
        {
            timer = cooldown;
            startCoolDown = false;
            cooldownStarted = true;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else if(timer <= 0 && cooldownStarted)
        {
            countDownFinished = true;
            Destroy(gameObject);
        }
	}
}
