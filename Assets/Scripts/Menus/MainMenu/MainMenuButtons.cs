using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public static event Action<int> OnOpeningSettingsButton;

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettingsMenu() 
    {
        OnOpeningSettingsButton?.Invoke(1);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    
}
