using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Robo : MonoBehaviour
{
    [Serializable]
    public struct Speak
    {
        public string speaksText;
    }

    public Speak[] speaks;
    public TextMeshProUGUI speaksTextUI;
    public GameObject panelQuestion;
    public GameObject panelSpeakRobo;
    private int currentSpeaksIndex = 0;
    private bool gameEndedSpeak = false;

    private void Start()
    {
        DisplaySpeak();
    }

    private void DisplaySpeak()
    {
        if (currentSpeaksIndex < speaks.Length)
        {
            Speak currentSpeak = speaks[currentSpeaksIndex];
            speaksTextUI.text = currentSpeak.speaksText;
        }
        else
        {
            EndSpeak();
        }
    }

    public void SpeackSelected()
    {
        if (gameEndedSpeak)
        {
            Debug.Log("Speak finish");
            return;
        }

        currentSpeaksIndex++;
        DisplaySpeak();
    }

    private void EndSpeak()
    {
        gameEndedSpeak = true;
        panelQuestion.SetActive(true);
        panelSpeakRobo.SetActive(false);
    }
}
