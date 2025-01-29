using System;

public class CloseSettingsMenuTransition : IMenusTransitionRule
{
    public Type NextState => typeof(PauseState);

    public bool ShouldTransition(float deltaTime)
    {
        throw new NotImplementedException(); // если нажата кнопка выхода или esc - true, в ост случаях false
    }
}
