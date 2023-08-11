using UnityEngine;


namespace Game.Zombie
{
    internal sealed class ZombieAnimatorListener : MonoBehaviour
    {
        [SerializeField] private ZombieModel model;

        //Method need for Unity's Animator
        public void AttackAnimationCallback()
        {
            model.Core.Attack.DealDamage();
        }
    }
}
