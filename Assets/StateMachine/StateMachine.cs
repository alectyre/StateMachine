﻿using UnityEngine;
using System.Collections.Generic;

namespace StateMachine
{
    [System.Serializable]
    public class StateMachine : IStateMachine
    {
        [SerializeField] IState currentState;

        public IState CurrentState
        {
            get { return currentState; }
            set
            {
                if (currentState != null)
                {
                    currentState.Exit();
                    currentState = null; //Any good reason to do this?
                }

                if (value != null)
                {
                    currentState = value;
                    currentState.StateMachine = this;
                    currentState.Enter();
                }
            }
        }

        public void Run(float deltaTime)
        {
            if (currentState != null)
            {
                currentState.Run(deltaTime);
                StateMachineUtility.CheckTransitions(this, currentState.Transitions);
            }
        }
    }
}