using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public enum PanelMenu
    {
        PanelStart,
        PanelConf,
        PanelCredits,
        PanelSituacao,
        PanelResposta,
        GameScene,
    }

    public enum Situation
	{
        Q1,
        Q2,
        Q3
	}

    [SerializeField] private List<GameObject> listPanelMenu;

    public void PanelActivated(int idPanel)
	{
        listPanelMenu[idPanel].SetActive(true);

		foreach (var panel in listPanelMenu)
		{
            if(listPanelMenu[idPanel] != panel)
			{
                panel.SetActive(false);
			}
		}
	}

    public void PanelResposta(int idPanel)
	{
		if (listPanelMenu[idPanel].activeInHierarchy)
            listPanelMenu[idPanel].SetActive(false);
		else
			listPanelMenu[idPanel].SetActive(true);
	}

    public void ChooseSituation(int idSituation)
	{
        PanelActivated((int)PanelMenu.GameScene);
        Robo.instance.idSituation = idSituation;
	}

    public void ResetGame()
	{
        SceneManager.LoadScene("Game");
	}
}
