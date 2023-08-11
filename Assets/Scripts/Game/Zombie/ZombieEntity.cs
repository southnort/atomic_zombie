using Atomic.Declarative;
using UnityEngine;


namespace Game.Zombie
{
    internal sealed class ZombieEntity : Entity
    {
        [SerializeField]
        public ZombieModel Model;


        private void Awake()
        {
            Add(new LookAtTargetComponent(Model.Core.Rotator.LookTarget));
            Add(new MoveToPointComponent(Model.Core.Mover.TargetPoint));
            Add(new TakeDamageComponent(Model.Core.Life));
            Add(new HitPointsComponent(Model.Core.Life));
            Add(Model.Core.Attack);
        }
    }
}
