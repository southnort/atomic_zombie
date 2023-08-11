using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class GunCooldownController : IUpdateListener
    {
        private float _cooldown;
        private float _currentCooldown;

        internal void Construct(float cooldown)
        {
            _cooldown = cooldown;
        }



        void IUpdateListener.Update(float deltaTime)
        {
            _currentCooldown -= deltaTime;
        }

        internal void ResetTimer()
        {
            _currentCooldown = _cooldown;
        }

        internal bool CheckIsOnCooldown()
        {
            return _currentCooldown > 0;
        }
    }
}
