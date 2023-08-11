using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class BulletSpawner
    {
        [SerializeField] private BulletsPool bulletPools;
        [SerializeField] private Transform spawnPoint;


        internal BulletEntity SpawnBullet()
        {
            var bullet = bulletPools.SpawnObject();
            bullet.transform.position = spawnPoint.position;

            var timer = bullet.Get<Timer>();
            timer.StartTimer(() => bulletPools.DespawnObject(bullet));

            return bullet;
        }
    }
}
