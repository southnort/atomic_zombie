using System;
using UnityEngine;


namespace Game
{
    internal sealed class PlayerInput : MonoBehaviour
    {
        private const string HorizontalConstant = "Horizontal";
        private const string VerticalConstant = "Vertical";

        private Vector2 _inputVector;

        public Vector2 InputVector => _inputVector;

        public event Action OnMouseClicked;


        private void Update()
        {
            var horizontal = Input.GetAxis(HorizontalConstant);
            var vertical = Input.GetAxis(VerticalConstant);

            _inputVector.x = horizontal;
            _inputVector.y = vertical;

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClicked?.Invoke();
            }
        }
    }
}
