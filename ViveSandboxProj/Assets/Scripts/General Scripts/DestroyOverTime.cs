using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float timer = 0;
    private bool countDownFinished = false;

	// Update is called once per frame
    void Start()
    {
        timer = cooldown;
    }
	void Update ()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            if (!countDownFinished)
            {
                if (this.gameObject.GetComponent<Destroy>() != null)
                {
                    countDownFinished = true;
                    Destroy(gameObject);
                }
                else
                {
                    //Debug.Log("This object does not have a destroy script");
                }
            }
        }
	}
}
