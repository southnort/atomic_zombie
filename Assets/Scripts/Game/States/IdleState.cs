using Atomic.Declarative;
using Game.Player;
using System;

namespace Game.States
{
    [Serializable]
    internal sealed class IdleState : IState
    {
        private AnimatorController _animatorController;
        private PlayerTargetFind _targetFind;


        [Construct]
        public void Construct(PlayerModel_View view, PlayerTargetFind target)
        {
            _animatorController = view.Animator;
            _targetFind = target;
        }


        void IState.Enter()
        {
            _targetFind.Target.Value = null;
            _animatorController.SetMoving(0);
            _targetFind.IsEnabled = true;
        }

        void IState.Exit()
        {
            _targetFind.IsEnabled = false;
        }
    }
}
