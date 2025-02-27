using System;

public class OpenSettingsMenuTransition : IEventMenusTransitionRule
{
    public Type NextState => typeof(SettingsState);

    private UIInput uiInput;

    private bool isReady = false;

    public OpenSettingsMenuTransition(UIInput uiInput)
    {
        this.uiInput = uiInput;
    }   

    public bool ShouldTransition(float deltaTime)
    {
        return isReady;
    }

    public void Subscribe()
    {
        uiInput.OnForwardButtonClick += SetReady;
    }

    private void SetReady()
    {
        isReady = true;
    }

    public void Unsubscribe()
    {
        uiInput.OnForwardButtonClick -= SetReady;
    }
}
