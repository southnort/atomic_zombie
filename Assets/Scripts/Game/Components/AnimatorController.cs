using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class AnimatorController
    {
        [SerializeField]
        private Animator animator;

        private static readonly int Moving = Animator.StringToHash("moving");
        private static readonly int Damage = Animator.StringToHash("takeDamage");
        private static readonly int Dead = Animator.StringToHash("dead");
        private static readonly int Attack = Animator.StringToHash("attack");


        public void SetMoving(float moveSpeed)
        {
            animator.SetBool(Moving, moveSpeed != 0);
        }

        public void TakeDamage()
        {
            animator.SetTrigger(Damage);
        }

        public void SetDead()
        {
            animator.SetBool(Dead, true);
        }

        public void SetAttack()
        {
            animator.SetTrigger(Attack);
        }
    }
}
