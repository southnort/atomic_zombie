using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class CollisionComponent
    {
        public event Action<Collider> OnEntered
        {
            add => _sensor.OnEntered += value;
            remove => _sensor.OnEntered -= value;
        }

        private readonly CollisionSensor _sensor;

        public CollisionComponent(CollisionSensor sensor)
        {
            _sensor = sensor;
        }
    }
}
