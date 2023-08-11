using Atomic.Declarative;
using Game.Gun;
using Game.States;
using System;
using UnityEngine;

namespace Game.Player
{
    [Serializable]
    internal sealed class PlayerStates
    {
        public StateMachine StateMachine;


        [Section]
        public IdleState IdleState;

        [Section]
        public RunState RunState;

        [Section]
        public ShootState AttackState;

        [Section]
        public DeadState DeadState;



        [Construct]
        public void Construct(MoveSection movement, LifeSection life, PlayerTargetFind targetFind, GunModel_Core gunCore)
        {
            StateMachine.Construct(IdleState, RunState, AttackState, DeadState);


            life.isDead.OnChanged += dead =>
            {
                var stateType = dead ? typeof(DeadState) : typeof(IdleState);
                StateMachine.SwitchState(stateType);
            };


            movement.MovementDirection.OnChanged += direction =>
            {
                StateMachine.SwitchState(direction == Vector3.zero ? typeof(IdleState) : typeof(RunState));
            };

            targetFind.Target.OnChanged += target =>
            {
                if (target)
                {
                    StateMachine.SwitchState(typeof(ShootState));
                }
            };

            gunCore.Shooting.OnShoot += () =>
            {
                StateMachine.SwitchState(typeof(IdleState));
            };
        }
    }
}
