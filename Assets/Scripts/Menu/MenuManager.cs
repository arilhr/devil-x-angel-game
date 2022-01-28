using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Animator")]
    
    public Animator mainMenuAnim;

    [Header("Help Page")]
    public GameObject helpObj;
    public Animator helpAnim;
    private bool helpPageShowed;

    [Header("Credit Page")]
    public Animator creditAnim;

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

        Debug.Log($"{helpAnim.GetCurrentAnimatorStateInfo(0).length}");
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
}
