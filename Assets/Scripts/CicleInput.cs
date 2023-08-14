using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CicleInput : MonoBehaviour, IPointerClickHandler
{
    private float initialSize = 1.0f;
    private float targetSize = 0.5f;
    public GameObject hand;
    public GameObject paciente;
    public GameObject panelRobo;
    public GameObject btGameOver;
    public int tentativas;
    public int acertos;
    private Robo robo;
    public Image barra;

    private void Start()
    {
        robo = Robo.instance;
        transform.localScale = new Vector3(initialSize, initialSize, 1.0f);
    }

    private void FixedUpdate()
    {
        float newSize = transform.localScale.x - 0.5f * Time.deltaTime;
        transform.localScale = new Vector3(newSize, newSize, 1.0f);

        if (newSize < 0)
        {
            tentativas++;
            Debug.Log("n clicou");
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (transform.localScale.x <= targetSize)
            GetComponent<Image>().color = Color.green;
		else
            GetComponent<Image>().color = Color.red;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.localScale.x <= targetSize)
        {
            acertos++;
            Debug.Log(acertos / 10.0f);
            barra.fillAmount = acertos / 10.0f;
            tentativas++;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            hand.SetActive(true);

            StartCoroutine(DelayHand());

            IEnumerator DelayHand()
            {
                yield return new WaitForSeconds(0.5f);
                hand.SetActive(false);
            }
        }
        else
        {
            tentativas++;
            Debug.Log("Errou!");
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (tentativas > 15 && acertos < 10)
        {
            GameOver("Que pena! Tente outra vez");
        }
        else if (acertos == 10)
        {
            GameOver("Parabéns! Você salvou uma vida");
        }

    }

    public void GameOver(string fraseFinal)
    {
        paciente.SetActive(false);
        robo.isGameOver = true;
        panelRobo.SetActive(true);
        robo.speaksTextUI.text = fraseFinal;
        robo.btPassarTxt.SetActive(false);
        btGameOver.SetActive(true);
    }
}
