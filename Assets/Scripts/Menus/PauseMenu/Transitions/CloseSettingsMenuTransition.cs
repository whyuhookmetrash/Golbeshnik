using System;

public class CloseSettingsMenuTransition : IEventMenusTransitionRule
{

    private bool isReady = false;

    private UIInput uiInput;

    public Type NextState => typeof(PauseState);

    public CloseSettingsMenuTransition(UIInput uiInput) 
    {
        this.uiInput = uiInput;
    }

    public bool ShouldTransition(float deltaTime)
    {
        return isReady || uiInput.EscPressed;
    }

    public void Subscribe()
    {
        uiInput.OnExitButtonClick += SetReady;
    }

    private void SetReady() 
    {
        isReady = true;
    }

    public void Unsubscribe()
    {
        uiInput.OnExitButtonClick -= SetReady;
    }
}
