using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuCore : MonoBehaviour
{
    enum MenuStates { Pause, Settings,  Resume } // Pause - 0 (в меню паузы) ; Settings - 1 (в меню настроек) ; Resume - 2 (играем)

    [SerializeField]
    GameObject pauseMenu;
    CanvasGroup pauseGroup;

    [SerializeField]
    GameObject settingsMenu;
    CanvasGroup settingsGroup;

    MenuStates Menustate = MenuStates.Resume;

    public void OnEnable()
    {
        pauseGroup = pauseMenu.GetComponent<CanvasGroup>();
        settingsGroup = settingsMenu.GetComponent<CanvasGroup>();
        PSettingButtonsNEtc.OnClosingSettingsButton += ChangeCurrWindowWithState;
        PauseMenuButtons.OnPressingChangeMenuButton += ChangeCurrWindowWithState;

    }

    public void OnDisable()
    {
        PSettingButtonsNEtc.OnClosingSettingsButton -= ChangeCurrWindowWithState;
        PauseMenuButtons.OnPressingChangeMenuButton -= ChangeCurrWindowWithState;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menustate == MenuStates.Resume) // Escape
        {
            Menustate = MenuStates.Pause;
            ChangeCurrWindow();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menustate == MenuStates.Pause) // Escape
        {
            Menustate = MenuStates.Resume;
            ChangeCurrWindow();
        }
    }

    void ChangeCurrWindowWithState(int num) 
    {
        Menustate = (MenuStates)num;
        ChangeCurrWindow();
    }


    void ChangeCurrWindow() 
    {
        switch (Menustate) 
        {
            case MenuStates.Resume: // 2
                {
                    Time.timeScale = 1.0f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;

                    pauseGroup.alpha = 0f;
                    pauseGroup.interactable = false;
                    pauseGroup.blocksRaycasts = false;

                    settingsGroup.alpha = 0f;
                    settingsGroup.interactable = false;
                    settingsGroup.blocksRaycasts = false;

                    break;
                }
            case MenuStates.Pause: // 0
                {
                    Time.timeScale = 0.0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                    pauseGroup.alpha = 1f;
                    pauseGroup.interactable = true;
                    pauseGroup.blocksRaycasts = true;

                    settingsGroup.alpha = 0f;
                    settingsGroup.interactable = false;
                    settingsGroup.blocksRaycasts = false;

                    break;
                }
            case MenuStates.Settings: // 1
                {
                    Time.timeScale = 0.0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                    pauseGroup.alpha = 0f;
                    pauseGroup.interactable = false;
                    pauseGroup.blocksRaycasts = false;

                    settingsGroup.alpha = 1f;
                    settingsGroup.interactable = true;
                    settingsGroup.blocksRaycasts = true;

                    break;
                }
        }
    }

}
