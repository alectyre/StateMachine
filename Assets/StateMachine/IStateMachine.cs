﻿namespace StateMachine
{
    public interface IStateMachine
    {
        IState CurrentState { get; set; }

        void Run(float deltaTime);
    }
}