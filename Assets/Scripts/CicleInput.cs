using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CicleInput : MonoBehaviour, IPointerClickHandler
{
    private float initialSize = 1.0f;
    private float targetSize = 0.5f;
    public GameObject hand;
    public GameObject paciente;
    public GameObject panelRobo;
    public GameObject btGameOver;
    public GameObject panelPontos;
    public int tentativas;
    public int acertos;
    private Robo robo;
    public Image barra;
    public float time = 60;
    public TextMeshProUGUI txtPontos;
    public TextMeshProUGUI txtTime;
    public TextMeshProUGUI txtAcertos;
    public TextMeshProUGUI txtProfundidade;
    public float minAcertos = 100;
    public float maxTentativas = 120;
    public int profundidade;
    public int pontos;
    public float newSize;

    public AudioManager audioManager;

    private void Start()
    {
        robo = Robo.instance;
        pontos = 0;
        panelPontos.SetActive(false);
        transform.localScale = new Vector3(initialSize, initialSize, 1.0f);
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if(time < 0)
            time = 0;

        int t = (int)time;
        txtTime.text = "Tempo: " + t.ToString();

        newSize = transform.localScale.x - 1.2f * Time.deltaTime;
        transform.localScale = new Vector3(newSize, newSize, 1.0f);

        VerificarNaoInput(newSize);
        TrocarCorCicleInput();
        FimDeJogo();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.localScale.x <= targetSize)
        {
            audioManager.PlayAudio(1);
            PontosPorPeso(newSize);
            acertos++;
            txtAcertos.text = "Acertos: " + acertos.ToString();
            barra.fillAmount = acertos / maxTentativas;
            tentativas++;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            hand.SetActive(true);

            StartCoroutine(DelayHand());

            IEnumerator DelayHand()
            {
                yield return new WaitForSeconds(0.2f);
                hand.SetActive(false);
            }
        }
        else
        {
            audioManager.PlayAudio(2);
            if (acertos > 0)
			{
                acertos--;
                barra.fillAmount = acertos / maxTentativas;
            }
            
            tentativas++;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        if ((time <= 0 || tentativas > maxTentativas) && acertos < minAcertos)
		{
            GameOverUI("Que pena! Tente outra vez");
            panelPontos.SetActive(false);
        }
        
    }

    public void GameOverUI(string fraseFinal)
    {
        paciente.SetActive(false);
        robo.isGameOver = true;
        panelRobo.SetActive(true);
        robo.speaksTextUI.text = fraseFinal;
        robo.btPassarTxt.SetActive(false);
        btGameOver.SetActive(true);
    }

    public void FimDeJogo()
	{
        if (time <= 0 && acertos < minAcertos)
        {
            GameOverUI("Que pena! Tente outra vez");
            panelPontos.SetActive(false);
        }
        else if (time <= 0 && acertos > minAcertos)
        {
            GameOverUI("Parabéns! Você salvou uma vida");
            panelPontos.SetActive(true);
            pontos += acertos;
            txtPontos.text = pontos.ToString();
        }
    }

    public void TrocarCorCicleInput()
	{
        if (transform.localScale.x <= targetSize)
            GetComponent<Image>().color = Color.green;
        else
            GetComponent<Image>().color = Color.red;
    }

    public void VerificarNaoInput(float newSize)
	{
        if (newSize < 0)
        {
            if (acertos > 0)
            {
                acertos--;
                barra.fillAmount = acertos / maxTentativas;
            }

            tentativas++;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void PontosPorPeso(float scaleImg)
	{
        if (scaleImg > 0.4)
        {
            profundidade = 6;
            txtProfundidade.text = "Profundidade: " + profundidade.ToString();
            pontos += 2;
        }
        else if (scaleImg > 0.3)
        {
            profundidade = 5;
            txtProfundidade.text = "Profundidade: " + profundidade.ToString();
            pontos += 1;
        }
		else
		{
            profundidade = 4;
            txtProfundidade.text = "Profundidade: " + profundidade.ToString();
        } 
    }
}
