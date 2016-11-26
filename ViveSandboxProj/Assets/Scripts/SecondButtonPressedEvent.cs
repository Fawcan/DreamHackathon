using UnityEngine;
using System.Collections;

public class SecondButtonPressedEvent : ObjectEvent {

    [SerializeField] private GameObject firstButton;
    [SerializeField] public FirstButtonPressedEvent firstButtonPressedEv;

    [SerializeField] private float timerLow;
    [SerializeField] private float timerMax;

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
            firstButtonPressedEv.secondButtonPressed = true;
            firstButtonPressedEv.secondButtonPressable = false;
            firstButtonPressedEv.timerStopped = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (firstButtonPressedEv.timerStopped && firstButtonPressedEv.timer <= timerMax && firstButtonPressedEv.timer >= timerLow)
        {
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
            firstButtonPressedEv.sequenceComplete = true;
        }
        else if (firstButtonPressedEv.timerStopped && firstButtonPressedEv.timer != 0 && firstButtonPressedEv.timer > timerMax && firstButtonPressedEv.timer < timerMax)
        {
            firstButtonPressedEv.sequenceFailed = true;
        }

        if (firstButtonPressedEv.sequenceFailed)
        {
            firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;
            gameObject.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;

            firstButtonPressedEv.timerStopped = false;

            firstButtonPressedEv.secondButtonPressed = true;
            firstButtonPressedEv.secondButtonPressable = false;
            firstButtonPressedEv.firstButtonPressable = false;
            firstButtonPressedEv.firstButtonPressed = true;
        }
    }
}
