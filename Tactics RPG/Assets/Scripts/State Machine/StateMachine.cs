using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public virtual State CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            Transition(value);
        }
    }
        protected State _currentState;
        protected bool _inTransition;

        public virtual T GetState<T>() where T : State
        {
            T target = GetComponent<T>();
            if (target == null)
            {
                target = gameObject.AddComponent<T>();
            }
            return target;
        }

        public virtual void ChangeState<T>() where T : State
        {
            CurrentState = GetState<T>();
        }

        protected virtual void Transition(State value)
        {
            if (_currentState == value || _inTransition)
            {
                return;
            }
            _inTransition = true;

            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = value;

            if (_currentState != null)
            {
                _currentState.Enter();
            }
            _inTransition = false;
        }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.