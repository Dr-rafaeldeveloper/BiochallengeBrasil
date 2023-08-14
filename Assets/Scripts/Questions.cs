using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Questions : MonoBehaviour
{
    [Serializable]
    public struct Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public Question[] questions;
    public TextMeshProUGUI questionTextUI;
    public TextMeshProUGUI[] answerTextUI;

    private int currentQuestionIndex = 0;
    private bool gameEnded = false;
    private int points;
    public GameObject panelQuestions;
    public GameObject panelSpeakRobo;
    public GameObject panelGameScene;
    public GameObject panelMenu;
    public TextMeshProUGUI speakRoboTextUI;
    public GameObject btNextRobo;

    private void Start()
    {
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionTextUI.text = "Question: " + currentQuestion.questionText;
            for (int i = 0; i < currentQuestion.answers.Length; i++)
            {
                answerTextUI[i].text = (i + 1) + ") " + currentQuestion.answers[i];
            }
        }
        else
        {
            EndGame();
        }
    }

    public void AnswerSelected(int answerIndex)
    {
        if (gameEnded)
        {
            Debug.Log("O jogo acabou. Reinicie o jogo para jogar novamente.");
            return;
        }

        Question currentQuestion = questions[currentQuestionIndex];
        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Resposta correta!");
            points++;
        }
        else
        {
            Debug.Log("Resposta incorreta!");
        }

        currentQuestionIndex++;
        DisplayQuestion();
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Jogo encerrado. Parabéns!");
        Debug.Log("Pontuação: " + points);
        panelQuestions.SetActive(false);
        panelSpeakRobo.SetActive(true);
        btNextRobo.SetActive(false);
        speakRoboTextUI.text = "Você fez " + points + " pontos!";

        StartCoroutine(ReturnMenu());

        IEnumerator ReturnMenu()
        {
            yield return new WaitForSeconds(2);
            panelGameScene.SetActive(false);
            panelMenu.SetActive(true);

        }
    }
}
