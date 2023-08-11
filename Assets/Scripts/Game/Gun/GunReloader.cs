using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class GunReloader : IUpdateListener
    {
        [SerializeField] private float reloadTime;
        private float _currentReloadTimer;

        private GunBulletsCount _bulletsCount;

        [SerializeField]
        public AtomicEvent OnGunReloaded;

        public bool IsEnabled { get; set; } = true;


        public void Construct(GunBulletsCount bulletsCount)
        {
            _bulletsCount = bulletsCount;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (!IsEnabled) return;

            _currentReloadTimer -= deltaTime;

            if (_currentReloadTimer <= 0)
            {
                Reload();
                ResetTimer();
            }
        }

        private void Reload()
        {
            if (_bulletsCount.CurrentBulletsCount.Value < _bulletsCount.MaxBulletsCount.Value)
            {
                _bulletsCount.CurrentBulletsCount.Value++;
                OnGunReloaded?.Invoke();
            }
        }

        public void ResetTimer()
        {
            _currentReloadTimer = reloadTime;
        }
    }
}
