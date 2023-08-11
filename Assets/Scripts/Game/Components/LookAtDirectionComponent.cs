using Atomic;
using UnityEngine;


namespace Game
{
    internal sealed class LookAtDirectionComponent
    {
        private readonly IAtomicVariable<Vector3> _lookDirection;

        public LookAtDirectionComponent(IAtomicVariable<Vector3> lookDirection)
        {
            _lookDirection = lookDirection;
        }

        public void SetDirection(Vector3 direction)
        {
            _lookDirection.Value = direction;
        }
    }
}
