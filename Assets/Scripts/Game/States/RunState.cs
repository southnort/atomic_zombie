using Atomic.Declarative;
using Game.Player;
using System;
using UnityEngine;
using Yrr.Utils;

namespace Game.States
{
    [Serializable]
    internal sealed class RunState : IState
    {
        private Transform _rootTransform;
        private MoveSection _move;
        private RotateSection _rotate;
        private AnimatorController _animatorController;


        [Construct]
        public void Construct(Transform root, MoveSection move, RotateSection rotate, PlayerModel_View view)
        {
            _rootTransform = root;
            _move = move;
            _rotate = rotate;
            _animatorController = view.Animator;
        }

        void IState.Enter()
        {
            _rotate.LookTarget.Value = null;
            _rotate.LookDirection.Value = _move.MovementDirection.Value.InvertYZ();
            _animatorController.SetMoving(_move.MovementDirection.Value.sqrMagnitude);
        }

        void IState.Exit()
        {
            _rotate.LookDirection.Value = Vector3.zero;
        }
    }
}
