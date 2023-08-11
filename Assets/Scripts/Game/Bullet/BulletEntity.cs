using Atomic.Declarative;
using UnityEngine;


namespace Game
{
    internal sealed class BulletEntity : Entity
    {
        [SerializeField]
        public BulletModel Model;

        private void Awake()
        {
            Add(new MoveInDirectionComponent(Model.Core.Mover.MovementDirection));
            Add(new CollisionComponent(Model.Core.Collision.Sensor));
            Add(new DamageComponent());
            Add(Model.Core.Timer);
        }
    }
}
