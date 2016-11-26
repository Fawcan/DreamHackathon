using UnityEngine;
using System.Collections;

public class SecondButtonPressedEvent : ObjectEvent {

    [SerializeField] private GameObject firstButton; //Store the first button in the Inspector
    [SerializeField] public FirstButtonPressedEvent firstButtonPressedEv;

    [SerializeField] public float timerLow; //Set the low value for the timer interval
    [SerializeField] public float timerMax; //Set the high value for the timer interval

    // Use this for initialization
    void Start ()
    {
        firstButtonPressedEv = firstButton.GetComponent<FirstButtonPressedEvent>();
	}

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        if (firstButtonPressedEv.secondButtonPressable)
        {
            base.StartEvent(thisObj, otherObj);
            firstButtonPressedEv.secondButtonPressed = true; //At Event start, you cannot press the button again.
            firstButtonPressedEv.secondButtonPressable = false; //The button has been pressed
            firstButtonPressedEv.timerStopped = true; //Stop the timer
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //If the timer has been stopped by collision and timer being in between the interval, make the button green and complete the sequence.
        if (firstButtonPressedEv.timerStopped && firstButtonPressedEv.timer <= timerMax && firstButtonPressedEv.timer >= timerLow)
        {
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
            firstButtonPressedEv.sequenceComplete = true;
        }
        //If the timer has been stopped by collision and timer being outside the interval, make all the buttons red and fail the sequence.
        else if (firstButtonPressedEv.timerStopped && firstButtonPressedEv.timer > timerMax)
        {
            firstButtonPressedEv.sequenceFailed = true;
        }
        else if (firstButtonPressedEv.timerStopped && firstButtonPressedEv.timer < timerLow)
        {
            firstButtonPressedEv.sequenceFailed = true;
        }

        //If sequence wasn't completed, reset all the values to defualt.
        if (firstButtonPressedEv.timerSet && firstButtonPressedEv.timer <= 0)
        {
            firstButtonPressedEv.timer = 0;
            firstButtonPressedEv.timerSet = false;
            firstButtonPressedEv.timerStopped = false;

            firstButtonPressedEv.secondButtonPressed = false;
            firstButtonPressedEv.secondButtonPressable = false;
            firstButtonPressedEv.firstButtonPressable = true;
            firstButtonPressedEv.firstButtonPressed = false;

            firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE;
        }

        //If sequence failed, reset all the values to defualt and set the color of the buttons to red.
        if (firstButtonPressedEv.sequenceFailed)
        {
            firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;

            firstButtonPressedEv.timer = 0;
            firstButtonPressedEv.timerSet = false;
            firstButtonPressedEv.timerStopped = false;

            firstButtonPressedEv.secondButtonPressed = true;
            firstButtonPressedEv.secondButtonPressable = false;
            firstButtonPressedEv.firstButtonPressable = false;
            firstButtonPressedEv.firstButtonPressed = true;
        }
    }
}
