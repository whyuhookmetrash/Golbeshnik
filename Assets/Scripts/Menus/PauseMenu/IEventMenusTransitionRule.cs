using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventMenusTransitionRule : IMenusTransitionRule
{
    void Subscribe();
    void Unsubscribe();
}
