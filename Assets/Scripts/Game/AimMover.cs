using UnityEngine;

namespace Game
{
    internal sealed class AimMover : MonoBehaviour
    {
        [SerializeField] private LayerMask raycastLayerMask;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            SynchronizeWithMousePosition();
        }

        private void SynchronizeWithMousePosition()
        {
            var mouse = Input.mousePosition;
            var castPoint = _camera.ScreenPointToRay(mouse);
            if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity, raycastLayerMask))
            {
                transform.position = hit.point;
            }
        }

        private void Update()
        {
            SynchronizeWithMousePosition();
        }
    }
}
