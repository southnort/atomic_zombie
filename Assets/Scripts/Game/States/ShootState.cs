using Atomic.Declarative;
using Game.Player;
using System;


namespace Game.States
{
    [Serializable]
    internal sealed class ShootState : IState
    {
        private RotateSection _rotate;
        private PlayerTargetFind _targetFind;
        private PlayerAttack _playerAttack;


        [Construct]
        public void Construct(RotateSection rotate, PlayerTargetFind targetFind, PlayerAttack playerAttack)
        {
            _rotate = rotate;
            _targetFind = targetFind;
            _playerAttack = playerAttack;
        }


        void IState.Enter()
        {
            _rotate.LookTarget.Value = _targetFind.Target.Value;
            _playerAttack.IsEnabled = true;
        }

        void IState.Exit()
        {
            _playerAttack.IsEnabled = false;            
        }
    }
}
