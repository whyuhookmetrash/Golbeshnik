using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuButtonsNEtc : MonoBehaviour
{
    public static event Action<int> OnClosingSettingsButton;

    public void ExitButton() 
    {
        OnClosingSettingsButton?.Invoke(0);
    }
}
