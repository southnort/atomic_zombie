using System;
using UnityEngine;


namespace Game
{
    internal sealed class CollisionSensor : MonoBehaviour
    {
        public event Action<Collider> OnEntered
        {
            add => _onEntered += value;
            remove => _onEntered -= value;
        }

        private Action<Collider> _onEntered;


        private void OnTriggerEnter(Collider other)
        {
            _onEntered?.Invoke(other);
        }
    }
}
