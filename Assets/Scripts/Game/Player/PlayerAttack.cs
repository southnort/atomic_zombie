using Atomic.Declarative;
using Game.Gun;
using System;


namespace Game.Player
{
    [Serializable]
    internal sealed class PlayerAttack : IUpdateListener
    {
        private BulletShooter _gun;
        private const float Delay = 0.1f;
        private float _currentDelay = Delay;

        public bool IsEnabled;
       

        void IUpdateListener.Update(float deltaTime)
        {
            if (!IsEnabled) return;

            _currentDelay -= deltaTime;
            if (_currentDelay <= 0)
            {
                _currentDelay = Delay;
                if(_gun.IsAmmoEmpty()) return;
                _gun.TryShoot();
            }
        }

        [Construct]
        public void Construct(GunModel_Core gunCore)
        {
            _gun = gunCore.Shooting;
        }
    }
}
