using System.Collections.Generic;


namespace Game.States
{
    internal abstract class CompositeState : IState
    {
        private List<IState> _states = new();

        void IState.Enter()
        {
            foreach (var st in _states)
            {
                st.Enter();
            }
        }

        void IState.Exit()
        {
            foreach (var st in _states)
            {
                st.Exit();
            }
        }

        protected void SetStates(IState[] states)
        {
            _states = new List<IState>(states);
        }
    }
}
