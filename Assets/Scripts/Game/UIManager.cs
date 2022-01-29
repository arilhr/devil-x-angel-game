using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Top UI")]
    public TMP_Text timerText;

    [Header("End Game UI")]
    public GameObject winUI;
    public GameObject loseUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWinUI()
    {
        winUI.SetActive(true);
    }

    public void SetLoseUI()
    {
        loseUI.SetActive(true);
    }
}
