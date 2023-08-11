using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Zombie
{
    [Serializable]
    internal sealed class ZombieMover : IUpdateListener
    {
        public AtomicVariable<float> MoveSpeed;
        public AtomicVariable<float> StopDistance;
        public AtomicVariable<Transform> TargetPoint;
        public AtomicVariable<Vector3> MovementDirection;
        public bool IsEnabled { get; set; } = true;

        private Transform _rootTransform;

        [Construct]
        public void Construct(Transform rootTransform)
        {
            _rootTransform = rootTransform;
        }


        void IUpdateListener.Update(float deltaTime)
        {
            if (TargetPoint.Value == null) return;
            if (!IsEnabled) return;

            var dist = (_rootTransform.position - TargetPoint.Value.position).sqrMagnitude;
            if (dist >= StopDistance.Value * StopDistance.Value)
            {
                var moveVector = _rootTransform.forward;
                MovementDirection.Value = moveVector;
            }

            else
            {
                MovementDirection.Value = Vector3.zero;
            }

            _rootTransform.position += MovementDirection.Value * (MoveSpeed.Value * deltaTime);
        }
    }
}
