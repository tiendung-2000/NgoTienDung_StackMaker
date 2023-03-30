using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController Ins;

    public static UIController Instance
    {
        get
        {
            if (Ins == null)
            {
                Ins = FindObjectOfType<UIController>();
            }

            return Ins;
        }
    }

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    TMP_Text levelTxt;


    public void WinUI()
    {
        PanelOnOff(winPanel, true);
    }

    public void UpdateLevelTXt(int level)
    {
        levelTxt.text = level.ToString();
    }

    public void ResetUI()
    {
        PanelOnOff(winPanel, false);
    }

    void PanelOnOff(GameObject m, bool l)
    {
        if (m)
            m.SetActive(l);
    }
}
