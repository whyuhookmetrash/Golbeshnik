using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MenusState
{

    private CanvasGroup pauseGroup;

    public PauseState(CanvasGroup pGroup) 
    {
        pauseGroup = pGroup;
    }

    public override void Enter()
    {
        pauseGroup.alpha = 1f;
        pauseGroup.interactable = true;
        pauseGroup.blocksRaycasts = true;
    }

    public override void Exit()
    {
        pauseGroup.alpha = 0f;
        pauseGroup.interactable = false;
        pauseGroup.blocksRaycasts = false;
    }
}
