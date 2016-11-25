﻿using UnityEngine;
using System.Collections;

public class ButtonSequencer : MonoBehaviour {

    [SerializeField] private GameObject firstButton; //Set in the Editor
    [SerializeField] private GameObject secondButton; //Set in the Editor

    [SerializeField] private bool sequenceStarted = false;
    [SerializeField] private bool sequenceComplete = false;
    [SerializeField] private bool firstButtonPressable = true;
    [SerializeField] private bool secondButtonPressable = false;

    [SerializeField] private float firstButtonTimer; //Set in the Editor

    [SerializeField] private float firstButtonStartTimer; //Set in the Editor, the starting value for the timer at execution

    [SerializeField] private float secondButtonIntervalLow; //Set in the Editor, the lowest interval for second button press.
    [SerializeField] private float secondButtonIntervalHigh; //Set in the Editor, the highest interval for second button press.

    // Use this for initialization
    void Start ()
    {
        firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
        secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!sequenceComplete)
        {
            if (firstButtonTimer <= 0 && Input.GetKeyDown(KeyCode.Z))
            {
                sequenceStarted = true;
                firstButtonPressable = false;
                secondButtonPressable = true;

                firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
                secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;

                firstButtonTimer = firstButtonStartTimer;
            }

            if (sequenceStarted)
            {
                if (firstButtonTimer <= secondButtonIntervalHigh && firstButtonTimer >= secondButtonIntervalLow && Input.GetKeyDown(KeyCode.X))
                {
                    secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
                    sequenceStarted = false;
                    sequenceComplete = true;
                }
                else if (firstButtonTimer >= secondButtonIntervalHigh && Input.GetKeyDown(KeyCode.X) && secondButtonPressable)
                {
                    firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;
                    secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;
                    firstButtonPressable = false;
                    secondButtonPressable = false;
                    sequenceStarted = false;
                }

                if (firstButtonTimer <= 0)
                {
                    sequenceStarted = false;
                    firstButtonPressable = true;
                }

                if (firstButtonTimer <= secondButtonIntervalHigh && firstButtonTimer >= secondButtonIntervalLow)
                {
                    secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
                }
                else if (firstButtonTimer < secondButtonIntervalLow)
                {
                    secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.RED;
                }
            }
            else if (!sequenceStarted && firstButtonTimer < 0)
            {
                firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.YELLOW;
                secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.WHITE;
            }

            if (firstButtonTimer > 0)
            {
                firstButtonTimer -= Time.deltaTime;
            }
        }
        else if (sequenceComplete)
        {
            firstButtonTimer = 0;
            firstButtonPressable = false;
            secondButtonPressable = false;
            firstButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
            secondButton.GetComponent<ColorManager>().NewColor = ColorManager.Colors.GREEN;
        }
	}
}