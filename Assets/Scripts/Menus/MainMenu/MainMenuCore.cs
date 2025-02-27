using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCore : MonoBehaviour
{
    [SerializeField]
    GameObject Mainmenu;
    CanvasGroup Maingroup;

    [SerializeField]
    GameObject Settingsmenu;
    CanvasGroup Settingsgroup;

    private void OnEnable()
    {
        Maingroup = Mainmenu.GetComponent<CanvasGroup>();
        Settingsgroup = Settingsmenu.GetComponent<CanvasGroup>();
        MainMenuButtons.OnOpeningSettingsButton += ChangeCurWindow;
        SettingsMenuButtonsNEtc.OnClosingSettingsButton += ChangeCurWindow;
    }

    private void OnDisable()
    {
        MainMenuButtons.OnOpeningSettingsButton -= ChangeCurWindow;
        SettingsMenuButtonsNEtc.OnClosingSettingsButton -= ChangeCurWindow;
    }


    void ChangeCurWindow(int num) // 0 - main; 1 - sett 
    {
        if (num == 0) 
        {
            Settingsgroup.alpha = 0f;
            Settingsgroup.interactable = false;
            Settingsgroup.blocksRaycasts = false;

            Maingroup.alpha = 1f;
            Maingroup.interactable = true;
            Maingroup.blocksRaycasts = true;
        }
        else 
        {
            Settingsgroup.alpha = 1f;
            Settingsgroup.interactable = true;
            Settingsgroup.blocksRaycasts = true;

            Maingroup.alpha = 0f;
            Maingroup.interactable = false;
            Maingroup.blocksRaycasts = false;
        }

    }

}
