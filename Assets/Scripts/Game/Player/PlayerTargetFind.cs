using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Player
{
    [Serializable]
    internal sealed class PlayerTargetFind : IUpdateListener
    {
        [SerializeField] private TargetFinder targetFinder;

        public AtomicVariable<Transform> Target;

        public bool IsEnabled;

        void IUpdateListener.Update(float deltaTime)
        {
            if (!IsEnabled) return;

            if (Target.Value == null)
            {
                Target.Value = targetFinder.GetNearestEnemy();
            }
        }
    }
}
