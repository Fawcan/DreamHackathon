using UnityEngine;
using System.Collections;

public class FirstButtonPressedEvent : ObjectEvent {

    [SerializeField] private GameObject secondButton;

    [SerializeField] public bool firstButtonPressable = true;
    [SerializeField] public bool firstButtonPressed = false;

    [SerializeField] public bool secondButtonPressable = false;
    [SerializeField] public bool secondButtonPressed = false;

    [SerializeField] public float timer;
    [SerializeField] private float timerStartValue;
    [SerializeField] private bool timerSet = false;
    [SerializeField] public bool timerStopped = false;

    [SerializeField] public bool sequenceComplete = false;
    [SerializeField] public bool sequenceFailed = false;

    void Start()
    {
        gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
        secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE;
    }

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        if (firstButtonPressable)
        {
            base.StartEvent(thisObj, otherObj);
            firstButtonPressable = false;
            firstButtonPressed = true;

            secondButtonPressable = true;

            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
            secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
        }
    }

    void Update()
    {
        if (firstButtonPressed && !timerSet)
        {
            timerSet = true;
            timer = timerStartValue;
        }

        if (timer > 0 && !timerStopped)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !sequenceComplete)
        {
            firstButtonPressable = true;
            firstButtonPressed = false;
            secondButtonPressable = false;
            secondButtonPressed = false;
        }

        if (sequenceComplete) //Call another event since the puzzle is solved.
        {
            timer = 0;
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
            secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
        }
    }
}
