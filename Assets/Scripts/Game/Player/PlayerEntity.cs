using Atomic.Declarative;
using Game.Gun;
using UnityEngine;

namespace Game.Player
{
    internal sealed class PlayerEntity : Entity
    {
        [SerializeField]
        private PlayerModel Model;

        [SerializeField]
        private GunEntity Gun;


        private void Awake()
        {
            Add(new MoveInDirectionComponent(Model.Core.Mover.MovementDirection));
            Add(new LookAtTargetComponent(Model.Core.Rotator.LookTarget));
            Add(new LookAtDirectionComponent(Model.Core.Rotator.LookDirection));
            Add(new TakeDamageComponent(Model.Core.Life));
            Add(new HitPointsComponent(Model.Core.Life));
            Add(new DeathComponent(Model.Core.Life));
            Add(new GunComponent(Gun));
        }
    }
}
