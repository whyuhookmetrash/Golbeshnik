using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenusState
{
    protected List<IMenusTransitionRule> TransitionRules = new();
    
    public event Action<Type> OnTransition;
    
    public abstract void Enter();
   
    public void UpdateState(float deltaTime)
    {
        if (ShouldTransition(deltaTime))
            return;
    }

    public abstract void Exit();
    
    private bool ShouldTransition(float deltaTime)
    {
        foreach (IMenusTransitionRule rule in TransitionRules)
        {
            if (rule.ShouldTransition(deltaTime))
            {
                foreach (IMenusTransitionRule transition in TransitionRules)
                {
                    if (transition is IEventMenusTransitionRule eventMenusTransition)
                    {
                        eventMenusTransition.Unsubscribe();
                    }
                }
                OnTransition?.Invoke(rule.NextState);
                return true;
            }
        }
        return false;
    }
    
    public void AddTransition(IMenusTransitionRule rule)
    {
        TransitionRules.Add(rule);
        if (rule is IEventMenusTransitionRule eventTransition)
        {
            eventTransition.Subscribe();
        }
    }
}
