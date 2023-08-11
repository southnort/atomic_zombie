using Atomic.Declarative;
using Game.Gun;
using System;


namespace Game
{
    [Serializable]
    internal sealed class GunComponent : IGunComponent
    {
        public Entity Entity { get; }


        public GunComponent(GunEntity entity)
        {
            Entity = entity;
        }
    }
}
