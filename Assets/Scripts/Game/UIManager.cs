using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Top UI")]
    public TMP_Text timerText;

    [Header("End Game UI")]
    public GameObject winUI;
    public GameObject loseUI;

    public string menuScene;

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


    public void BackToMenu()
    {
        SceneChanger.instance.LoadScene(menuScene);
    }

    public void RestartGame()
    {
        SceneChanger.instance.LoadScene(gameObject.scene.name);
    }

    public void NextLevel()
    {
        if (LevelManager.instance.levels.Count - 1 > GameManager.instance.levelId)
        {
            int levelId = GameManager.instance.levelId;
            SceneChanger.instance.LoadScene(LevelManager.instance.levels[levelId + 1].sceneName);
        }
        else
        {
            SceneChanger.instance.LoadScene(menuScene);
        }
    }
}
