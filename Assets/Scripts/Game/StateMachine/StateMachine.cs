using Atomic.Declarative;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game.States
{
    [Serializable]
    public sealed class StateMachine : IState, IStartListener
    {
        [SerializeField]
        private bool enterOnStart = true;

        private IState _currentState;
        private Dictionary<Type, IState> _states = new();


        internal void Construct(params IState[] states)
        {
            _states = new Dictionary<Type, IState>();
            foreach (var st in states)
            {
                _states.Add(st.GetType(), st);
            }
        }

        void IStartListener.Start()
        {
            if (enterOnStart)
            {
                Enter();
            }
        }


        public void Enter()
        {
            _currentState?.Enter();
        }

        public void Exit()
        {
            _currentState?.Exit();
            _currentState = null;
        }

        internal void SwitchState(Type stateType)
        {
            if (_currentState is DeadState) return;

            if (_states.TryGetValue(stateType, out var state))
            {
                Exit();
                _currentState = state;
                Enter();
            }

            else
            {
                throw new InvalidOperationException(stateType.Name + " is not a state!!");
            }
        }
    }
}
