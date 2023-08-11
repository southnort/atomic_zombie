using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Player
{
    [Serializable]
    internal sealed class PlayerModel_View
    {
        [SerializeField]
        public AnimatorController Animator;

        [SerializeField]
        public ParticleSystem ParticleSystem;


        [Construct]
        public void Construct(PlayerModel_Core core)
        {
            core.Life.hitPoints.OnChanged += hp =>
            {
                Animator.TakeDamage();
                ParticleSystem.Play();
            };
        }
    }
}
