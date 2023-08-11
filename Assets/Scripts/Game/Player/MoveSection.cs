using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;
using Yrr.Utils;

namespace Game
{
    [Serializable]
    internal sealed class MoveSection : IUpdateListener
    {
        public AtomicVariable<float> MoveSpeed;
        public AtomicVariable<Vector3> MovementDirection;
        private Transform _transform;

        public bool IsEnabled { get; set; } = true;

        [Construct]
        public void Construct(Transform rootTransform)
        {
            _transform = rootTransform;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (!IsEnabled) return;
            var moveVector = MovementDirection.Value.InvertYZ();

            _transform.position += moveVector * (MoveSpeed.Value * deltaTime);
        }
    }
}
