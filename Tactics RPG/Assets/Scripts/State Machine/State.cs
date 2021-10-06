using System;
using System.Collections;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void Enter()
    {
        AddListeners();
    }

    public virtual void Exit()
    {
        RemoveListeners();
    }

    protected void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void AddListeners()
    {
        
    }

    protected virtual void RemoveListeners()
    {
        
    }
}
