using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float timer = 0;

	
	// Update is called once per frame
	void Update ()
    {
	    if(timer >= cooldown)
        {
            Destroy(gameObject);
        }

        else
        {
            timer += Time.deltaTime;
        }
	}
}
