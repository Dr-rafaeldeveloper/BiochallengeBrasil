using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public enum PanelMenu
    {
        PanelStart,
        PanelConf,
        PanelCredits,
        GameScene
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
}
