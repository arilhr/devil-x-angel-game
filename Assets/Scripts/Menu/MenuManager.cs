using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Serializable]
    public struct LevelButton
    {
        public GameObject openButton;
        public GameObject lockButton;
    }

    [Header("Help Page")]
    public GameObject helpObj;
    public Animator helpAnim;
    private bool helpPageShowed;

    [Header("Credit Page")]
    public Animator creditAnim;

    [Header("Play Page")]
    public Animator playAnim;
    public GameObject playObj;
    public List<LevelButton> levelButtons;


    private void Start()
    {
        LevelManager.instance.LoadData();
        SetLevelButton();
    }

    #region Help Page
    public void ShowHelpPage()
    {
        helpObj.SetActive(true);
        helpAnim.SetTrigger("Show");
        helpPageShowed = true;
    }

    public void HideHelpPage()
    {
        if (helpPageShowed)
        {
            StartCoroutine(OnHideHelpPage());
            helpPageShowed = false;
        }
    }

    private IEnumerator OnHideHelpPage()
    {
        helpAnim.SetTrigger("Hide");

        yield return new WaitForSeconds(helpAnim.GetCurrentAnimatorStateInfo(0).length);

        Debug.Log($"inactive");
        helpObj.SetActive(false);
    }
    #endregion

    #region Credit Page
    public void ShowCreditPage()
    {
        creditAnim.SetTrigger("Show");
    }

    public void HideCreditPage()
    {
        creditAnim.SetTrigger("Hide");
    }

    #endregion

    #region Play Page
    public void ShowPlayPage()
    {
        playObj.SetActive(true);
        playAnim.SetTrigger("Show");
    }

    public void HidePlayPage()
    {
        StartCoroutine(OnHidePlayPage());
    }

    private IEnumerator OnHidePlayPage()
    {
        playAnim.SetTrigger("Hide");

        yield return new WaitForSeconds(playAnim.GetCurrentAnimatorStateInfo(0).length);

        playObj.SetActive(false);
    }

    private void SetLevelButton()
    {
        for (int i = 0; i < LevelManager.instance.levels.Count; i++)
        {
            bool isOpen = LevelManager.instance.levels[i].isOpen;
            string sceneName = LevelManager.instance.levels[i].sceneName;
            levelButtons[i].openButton.SetActive(isOpen);
            levelButtons[i].lockButton.SetActive(!isOpen);
            levelButtons[i].openButton.GetComponent<Button>().onClick.AddListener(() => SceneChanger.instance.LoadScene(sceneName));
        }
    }
    #endregion
}
