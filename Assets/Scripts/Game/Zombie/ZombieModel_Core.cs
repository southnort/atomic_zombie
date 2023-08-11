using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Zombie
{
    [Serializable]
    internal sealed class ZombieModel_Core
    {
        public Transform Transform;

        [Section]
        [SerializeField]
        public LifeSection Life;

        [Section]
        [SerializeField]
        public ZombieMover Mover;

        [Section]
        [SerializeField]
        public RotateSection Rotator;
       

        [SerializeField]
        public ZombieAttack Attack;


        [Construct]
        public void Construct()
        {
            Life.isDead.OnChanged += (dead) =>
            {
                Mover.IsEnabled = !dead;
                Mover.MovementDirection.Value = Vector3.zero;
                Rotator.IsEnabled = !dead;
            };

            Attack.Construct(Transform, Life);
        }
    }
}
