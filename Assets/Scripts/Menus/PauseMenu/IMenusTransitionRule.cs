using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenusTransitionRule
{
    bool ShouldTransition(float deltaTime);
    Type NextState { get; }
}
