using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform _camTransform;
        private float _rotateEdgeX = 45.0f;
        private float _lookSpeed = 4.0f;

        private Vector2 _mouseDirection;
        private Vector2 _mouseLook;
        private Vector2 _currentDir;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

        public void Look()
        {
            _mouseDirection = Vector2.Scale(
                new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), 
                new Vector2(_lookSpeed, _lookSpeed));

            if (_mouseDirection.x != 0.0f)
                RotateHorizontal();

            if ( _mouseDirection.y != 0.0f)
                RotateVertical();
        }

        private void RotateHorizontal()
        {
            _currentDir.x = Mathf.Lerp(_currentDir.x, _mouseDirection.x, 1f / _lookSpeed);
            _mouseLook.x += _currentDir.x;
            transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, transform.up);
        }

        private void RotateVertical()
        {
            _currentDir.y = Mathf.Lerp(_currentDir.y, _mouseDirection.y, 1f / _lookSpeed);
            _mouseLook.y += _currentDir.y;
            _camTransform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-_mouseLook.y, -_rotateEdgeX, _rotateEdgeX), Vector3.right);
        }
    }
}
