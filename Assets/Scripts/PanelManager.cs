using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Backgrounds
{
    aviao,
    parque,
    praia,
    aviaop1,
    parquep2,
    praiap3
}

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
    public List<GameObject> listBackground;
    public AudioManager audioManager;

    public void PanelActivated(int idPanel)
	{
        listPanelMenu[idPanel].SetActive(true);
        audioManager.PlayAudio(0);

        foreach (var panel in listPanelMenu)
		{
            if(listPanelMenu[idPanel] != panel)
			{
                panel.SetActive(false);
			}
		}
	}

    public void BackgroundActivated(int idBackground)
    {
        listBackground[idBackground].SetActive(true);

        foreach (var panel in listBackground)
        {
            if (listBackground[idBackground] != panel)
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

		switch (idSituation)
		{
            case (int)Situation.Q1:
                BackgroundActivated((int)Backgrounds.aviao);
                break;

            case (int)Situation.Q2:
                BackgroundActivated((int)Backgrounds.parque);
                break;

            case (int)Situation.Q3:
                BackgroundActivated((int)Backgrounds.praia);
                break;
        }
	}

    public void ResetGame()
	{
        audioManager.PlayAudio(0);
        SceneManager.LoadScene("01_Gameplay");
	}

    public void BackgroundPacientChoose(int idSituation)
	{
        switch (idSituation)
        {
            case (int)Situation.Q1:
                BackgroundActivated((int)Backgrounds.aviaop1);
                break;

            case (int)Situation.Q2:
                BackgroundActivated((int)Backgrounds.parquep2);
                break;

            case (int)Situation.Q3:
                BackgroundActivated((int)Backgrounds.praiap3);
                break;
        }
    }
}
