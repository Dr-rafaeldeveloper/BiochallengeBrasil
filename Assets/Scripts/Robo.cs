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
        public string[] speaksText;
    }

    public Speak[] speaks;
    public int idSituation;
    public TextMeshProUGUI speaksTextUI;
    public GameObject paciente;
    public GameObject panelSpeakRobo;
    public GameObject btPassarTxt;
    private int currentSpeaksIndex = 0;
    private bool gameEndedSpeak = false;
    public static Robo instance;
    public bool isGameOver;
    public PanelManager panelManager;
    public AudioManager audioManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!isGameOver)
            DisplaySpeak();
    }

    private void DisplaySpeak()
    {
        btPassarTxt.SetActive(true);
        if (currentSpeaksIndex < speaks.Length)
        {
            Speak currentSpeak = speaks[currentSpeaksIndex];
            speaksTextUI.text = currentSpeak.speaksText[idSituation];
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
        audioManager.PlayAudio(0);
        currentSpeaksIndex++;
        DisplaySpeak();
    }

    private void EndSpeak()
    {
        gameEndedSpeak = true;
        paciente.SetActive(true);
        panelManager.BackgroundPacientChoose(idSituation);
        panelSpeakRobo.SetActive(false);
    }
}
