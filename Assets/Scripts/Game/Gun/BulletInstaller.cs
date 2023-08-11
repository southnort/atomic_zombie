using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class BulletInstaller
    {
        [SerializeField] private Transform firePoint;
        private int _damage;


        public void Construct(int damage)
        {
            _damage = damage;
        }

        internal void SetupBullet(BulletEntity bullet)
        {
            var damage = bullet.Get<DamageComponent>();
            damage.Damage = _damage;

            var mover = bullet.Get<MoveInDirectionComponent>();
            var forward = firePoint.forward;
            var direction = new Vector2(forward.x, forward.z);
            mover.MoveInDirection(direction);
        }
    }
}
