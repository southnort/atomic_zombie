using Atomic.Declarative;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    internal sealed class DamageDealer : MonoBehaviour
    {
        [SerializeField] private Entity bullet;

        private void Awake()
        {
            bullet.Get<CollisionComponent>().OnEntered += (collision) =>
            {
                if (!collision.gameObject.TryGetComponent<Entity>(out var entity)) return;
                if (!entity.TryGet<TakeDamageComponent>(out var takeDamageComponent)) return;

                var bulletDamage = bullet.Get<DamageComponent>();
                takeDamageComponent.TakeDamage(bulletDamage.Damage);
            };
        }
    }
}
