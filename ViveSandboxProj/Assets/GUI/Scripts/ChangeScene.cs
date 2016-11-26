using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : ObjectEvent
{
    [SerializeField] private float timer;
    [SerializeField] private float cooldown;
    [SerializeField] private bool timerStarted = false;
    [SerializeField] private LevelManager levelManager;

    
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("manager").GetComponent<LevelManager>();
    }

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        base.StartEvent(thisObj, otherObj);
        if (!timerStarted)
        {
            timer = cooldown;
        }
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            levelManager.LoadNextLevel();
        }
    }
}
