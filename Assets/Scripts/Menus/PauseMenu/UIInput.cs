using System;
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

    public void ExitButtonClick() // ��������� �� ������ ������
    {
        OnExitButtonClick?.Invoke();
    }

    public void SettingsButton() // ��������� �� ������ �������� (������ ������)
    {
        OnForwardButtonClick?.Invoke();
    }

    public void ExitScene() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
