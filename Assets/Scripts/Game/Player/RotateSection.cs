using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class RotateSection : IUpdateListener
    {
        public AtomicVariable<Transform> LookTarget;
        public AtomicVariable<Vector3> LookDirection;
        private Transform _rootTransform;
        public bool IsEnabled { get; set; } = true;

        [Construct]
        public void Construct(Transform rootTransform)
        {
            _rootTransform = rootTransform;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (!IsEnabled) return;

            if (LookTarget.Value != null)
            {
                _rootTransform.LookAt(LookTarget.Value);
            }

            else
            {
                _rootTransform.LookAt(_rootTransform.position + LookDirection.Value);
            }
        }
    }
}
