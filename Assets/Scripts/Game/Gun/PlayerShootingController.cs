using Atomic.Declarative;
using UnityEngine;


namespace Game
{
    internal sealed class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private Entity gunEntity;

        private ShootingComponent _shooting;

        private void Start()
        {
            _shooting = gunEntity.Get<ShootingComponent>();
            input.OnMouseClicked += ShotLogic;
        }

        private void OnDestroy()
        {
            input.OnMouseClicked -= ShotLogic;
        }

        private void ShotLogic()
        {
            _shooting.Shoot();
        }
    }
}
