using System;

public interface IButtonInput 
{
    event Action OnExitButtonClick;
    event Action OnForwardButtonClick;
}
