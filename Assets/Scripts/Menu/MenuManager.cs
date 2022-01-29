using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Header("Help Page")]
    public GameObject helpObj;
    public Animator helpAnim;
    private bool helpPageShowed;

    [Header("Credit Page")]
    public Animator creditAnim;

    [Header("Play Page")]
    public Animator playAnim;
    public GameObject playObj;

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
    #endregion
}
