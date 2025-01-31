using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInput : MonoBehaviour, IButtonInput
{
    public event Action OnExitButtonClick;
    public event Action OnForwardButtonClick;

    public bool EscPressed = false;

    private void Update()
    {
        EscPressed = Input.GetKeyDown(KeyCode.Escape);
    }

    public void ExitButtonClick() // назначить на кнопку выхода
    {
        OnExitButtonClick?.Invoke();
    }

    public void SettingsButton() // назначить на кнопку настроек (уходим вглубь)
    {
        OnForwardButtonClick?.Invoke();
    }

    public void ExitScene() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
