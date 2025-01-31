using System;

public class ResumeMenuTransition : IEventMenusTransitionRule
{
    public Type NextState => typeof(ResumeState);

    private UIInput uiInput;

    private bool isReady = false;

    public ResumeMenuTransition(UIInput uiInput)
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
