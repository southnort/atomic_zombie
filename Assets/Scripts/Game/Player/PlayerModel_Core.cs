using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Player
{
    [Serializable]
    internal sealed class PlayerModel_Core
    {
        public Transform Transform;

        [Section]
        [SerializeField]
        public LifeSection Life;

        [Section]
        [SerializeField]
        public MoveSection Mover;

        [Section]
        [SerializeField]
        public RotateSection Rotator;

        [Section]
        [SerializeField]
        public PlayerStates States;

        [Section]
        [SerializeField]
        public PlayerTargetFind Target;

        [Section]
        [SerializeField]
        public PlayerAttack Attack;
    }
}
