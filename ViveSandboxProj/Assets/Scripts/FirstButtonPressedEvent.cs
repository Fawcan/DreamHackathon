using UnityEngine;
using System.Collections;

public class FirstButtonPressedEvent : ObjectEvent {

    [SerializeField] private GameObject secondButton; //Store the second button in the Inspector
    [SerializeField] public SecondButtonPressedEvent secondButtonPressedEv;

    [SerializeField] public bool firstButtonPressable = true; //If the player can press the first button
    [SerializeField] public bool firstButtonPressed = false; //If the player has pressed the first button

    [SerializeField] public bool secondButtonPressable = false; //If the player can press the second button
    [SerializeField] public bool secondButtonPressed = false; //If the player has pressed the second button

    [SerializeField] public float timer; //Timer for sequence
    [SerializeField] private float timerStartValue; //The start value to tick down, set in the inspector
    [SerializeField] public bool timerSet = false; //If the timer has been set
    [SerializeField] public bool timerStopped = false; //If the timer has been stopped to check it's value.

    [SerializeField] public bool sequenceComplete = false; //If the sequence is finished
    [SerializeField] public bool sequenceFailed = false; //If the player failed to complete the sequence

    void Start()
    {
        gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW; //Set the defualt color of the first button to yellow, indicating it can be pressed.
        secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE; //Set the defualt color of the second button to white, indicating it cannot can be pressed.
        secondButtonPressedEv = secondButton.GetComponent<SecondButtonPressedEvent>();
    }

    public override void StartEvent(GameObject thisObj, GameObject otherObj)
    {
        if (firstButtonPressable)
        {
            base.StartEvent(thisObj, otherObj);
            firstButtonPressable = false; //At Event start, you cannot press the button again.
            firstButtonPressed = true; //The button has been pressed

            secondButtonPressable = true; //Make the second button pressable

            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN; //Change the color to green, inidcating it is finished.
            secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE;
        }
    }

    void Update()
    {
        if (firstButtonPressed && !timerSet) //If the button has been pressed and the timer hasn't been set.
        {
            timerSet = true;
            timer = timerStartValue; //Set the timer to it's starting value.
        }

        if (timer <= secondButtonPressedEv.timerMax && timer >= secondButtonPressedEv.timerLow) //While in between the intervals, make the button yellow.
        {
            secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
        }

        if (timer > 0 && !timerStopped) //Countdown as long as the timer hasn't been stopped.
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !sequenceComplete) //If the sequence wasn't completed or failed, set defualt values to flags.
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
