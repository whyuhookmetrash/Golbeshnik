using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : MenusState
{
    private CanvasGroup settingsGroup;

    public SettingsState(CanvasGroup sGroup) 
    {
        settingsGroup = sGroup;
    }

    public override void Enter()
    {
        settingsGroup.alpha = 1f;
        settingsGroup.interactable = true;
        settingsGroup.blocksRaycasts = true;
    }

    public override void Exit()
    {
        settingsGroup.alpha = 0f;
        settingsGroup.interactable = false;
        settingsGroup.blocksRaycasts = false;
    }
}
