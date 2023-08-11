using Atomic;
using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class BulletShooter
    {
        [SerializeField] private BulletSpawner spawner;

        [SerializeField]
        public BulletInstaller Setup;

        private GunBulletsCount _bulletsCount;
        private GunCooldownController _cooldownController;


        [SerializeField]
        public AtomicEvent OnShoot;

        [SerializeField]
        public AtomicEvent OnNoAmmoShot;



        public bool IsEnabled { get; set; } = true;



        internal void Construct(GunBulletsCount bulletsCount, GunCooldownController cooldownController)
        {
            _bulletsCount = bulletsCount;
            _cooldownController = cooldownController;
        }

        internal void Construct(int shotDamage)
        {
            Setup.Construct(shotDamage);
        }

        public bool IsAmmoEmpty()
        {

            return _bulletsCount.CurrentBulletsCount.Value <= 0;
        }

        public void TryShoot()
        {
            if (!IsEnabled) return;
            if (!CheckCanShoot())
            {
                return;
            }

            OnShoot?.Invoke();

            var bullet = spawner.SpawnBullet();
            Setup.SetupBullet(bullet);
        }

        private bool CheckCanShoot()
        {
            if (_bulletsCount.CurrentBulletsCount.Value <= 0)
            {
                OnNoAmmoShot?.Invoke();
                return false;
            }

            return !_cooldownController.CheckIsOnCooldown();
        }
    }
}
