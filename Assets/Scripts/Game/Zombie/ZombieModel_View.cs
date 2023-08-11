using Atomic.Declarative;
using Game.Zombie;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class ZombieModel_View
    {
        [SerializeField]
        public AnimatorController Animator;

        [SerializeField]
        public ParticleSystem ParticleSystem;



        [Construct]
        public void Construct(ZombieModel_Core core)
        {
            core.Life.isDead.OnChanged += dead =>
            {
                if (dead)
                    Animator.SetDead();
            };

            core.Mover.MovementDirection.OnChanged += (Vector3 direction) =>
            {
                Animator.SetMoving(direction.sqrMagnitude);
            };

            core.Life.hitPoints.OnChanged += hp =>
            {
                Animator.TakeDamage();
                ParticleSystem.Play();
            };           

            core.Attack.OnAttack += Animator.SetAttack;
        }
    }
}
