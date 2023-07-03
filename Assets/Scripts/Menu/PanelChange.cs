using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    public GameObject NewPanel;
    public GameObject ThisPanel;

    public void ChangePanels()
    {
        NewPanel.SetActive(true);
        ThisPanel.SetActive(false);
    }
}
