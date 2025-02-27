using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeState : MenusState
{

    private PlayerController playerController;

    public ResumeState(PlayerController pController) 
    {
        playerController = pController;
    }

    public override void Enter()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
    }

    public override void Exit()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = false;
    }
}
