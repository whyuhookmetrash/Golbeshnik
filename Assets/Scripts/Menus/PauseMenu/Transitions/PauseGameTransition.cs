using System;

public class PauseGameTransition : IMenusTransitionRule
{
    public Type NextState => typeof(PauseState);

    public bool ShouldTransition(float deltaTime)
    {
        throw new NotImplementedException();
    }
}
