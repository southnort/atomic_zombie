using Atomic.Declarative;
using UnityEngine;


namespace Game
{
    internal sealed class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;

        [SerializeField] private Entity playerEntity;

        private MoveInDirectionComponent _movement;


        private void Start()
        {
            _movement = playerEntity.Get<MoveInDirectionComponent>();
        }


        private void Update()
        {
            _movement.MoveInDirection(input.InputVector);
        }
    }
}
