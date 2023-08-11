using Atomic;
using UnityEngine;


namespace Game
{
    internal sealed class LookAtTargetComponent
    {
        private readonly IAtomicVariable<Transform> _lookTarget;

        public LookAtTargetComponent(IAtomicVariable<Transform> lookTarget)
        {
            _lookTarget = lookTarget;
        }

        public void SetTarget(Transform target)
        {
            _lookTarget.Value = target;
        }
    }
}
