using Atomic;
using UnityEngine;


namespace Game
{
    internal sealed class MoveToPointComponent
    {
        private readonly IAtomicVariable<Transform> _targetPoint;

        public MoveToPointComponent(IAtomicVariable<Transform> targetPoint)
        {
            _targetPoint = targetPoint;
        }

        public void SetTargetPoint(Transform targetPoint)
        {
            _targetPoint.Value = targetPoint;
        }
    }
}
