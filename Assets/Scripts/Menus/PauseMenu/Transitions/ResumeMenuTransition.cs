using System;

public class ResumeMenuTransition : IMenusTransitionRule
{
    public Type NextState => typeof(ResumeState);

    public bool ShouldTransition(float deltaTime)
    {
        throw new NotImplementedException();
    }
}
