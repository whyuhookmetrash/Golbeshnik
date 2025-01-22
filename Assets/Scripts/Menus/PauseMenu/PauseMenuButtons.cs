using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public static event Action<int> OnPressingChangeMenuButton;

    public void ResumeButton() 
    {
        OnPressingChangeMenuButton?.Invoke(2);
    }

    public void SettingsButton() 
    {
        OnPressingChangeMenuButton?.Invoke(1);
    }

    public void ExitButton() 
    {
        SceneManager.LoadScene(0);
    }
}
