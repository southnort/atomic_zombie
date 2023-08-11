using Atomic.Declarative;
using Game.Gun;
using Game.Player;
using System;
using UnityEngine;

namespace Game.States
{
    [Serializable]
    internal sealed class DeadState : IState
    {
        private AnimatorController _animatorController;
        private GunModel _gun;
        private MoveSection _move;
        private RotateSection _rotate;


        [Construct]
        public void Construct(PlayerModel_View view, PlayerModel_Core core, GunModel gun)
        {
            _animatorController = view.Animator;
            _gun = gun;
            _move = core.Mover;
            _rotate = core.Rotator;
        }


        void IState.Enter()
        {
            _animatorController.SetDead();

            _gun.Core.GunReloader.IsEnabled = false;
            _gun.Core.Shooting.IsEnabled = false;

            _move.MovementDirection.Value = Vector3.zero;
            _move.IsEnabled = false;

            _rotate.IsEnabled = false;
        }

        void IState.Exit()
        {
            //throw new NotImplementedException();
        }
    }
}
