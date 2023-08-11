using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class GunModel_Core
    {
        [SerializeField]
        public AtomicVariable<int> ShotDamage;

        [SerializeField]
        public AtomicVariable<float> ShootingCooldown;

        [SerializeField]
        public GunBulletsCount BulletsCount;

        [SerializeField]
        public GunReloader GunReloader;

        [SerializeField]
        public GunCooldownController CooldownController;



        [SerializeField]
        public BulletShooter Shooting;


        private bool _isConstructed;

        [Construct]
        public void Construct()
        {
            if(_isConstructed)  return; 
            _isConstructed = true;

            CooldownController.Construct(ShootingCooldown.Value);
            Shooting.Construct(BulletsCount, CooldownController);
            Shooting.Construct(ShotDamage.Value);
            GunReloader.Construct(BulletsCount);

            Shooting.OnShoot += () =>
            {
                GunReloader.ResetTimer();
                CooldownController.ResetTimer();
                BulletsCount.CurrentBulletsCount.Value--;
            };
        }
    }
}
