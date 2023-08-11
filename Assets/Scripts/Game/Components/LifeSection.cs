using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class LifeSection
    {
        [SerializeField]
        public AtomicVariable<int> hitPoints;

        [SerializeField]
        public AtomicVariable<bool> isDead;


        [Construct]
        public void Construct()
        {
            hitPoints.OnChanged = new AtomicEvent<int>();

            hitPoints.OnChanged += hp =>
            {
                if (hp <= 0)
                {
                    isDead.Value = true;
                }
            };
        }
    }
}
