using System;

public class PauseGameTransition : IMenusTransitionRule
{
    public Type NextState => typeof(PauseState);

    private UIInput uiInput;

    public PauseGameTransition(UIInput uiInput) 
    {
        this.uiInput = uiInput;
    }

    public bool ShouldTransition(float deltaTime)
    {
        return uiInput.EscPressed;
    }
}
