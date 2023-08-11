using Atomic;
using UnityEngine;


namespace Game
{
    internal sealed class MoveInDirectionComponent
    {
        private readonly IAtomicVariable<Vector3> _movementDirection;

        public MoveInDirectionComponent(IAtomicVariable<Vector3> movementDirection)
        {
            _movementDirection = movementDirection;
        }

        public void MoveInDirection(Vector3 direction)
        {
            _movementDirection.Value = direction;
        }
    }
}
