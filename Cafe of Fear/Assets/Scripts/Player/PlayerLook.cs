using Unity.Collections;
using UnityEngine;

namespace CafeOfFear
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform _camTransform;
        [SerializeField] private Camera _camera;

        public Vector3 PlayerLookDirection { get => _camTransform.forward; }

        [Header("Smoothing")]
        private float _smoothTime = 5f;
        private float _smoothMultiplier = 2f;

        [Header("Sensitivity")]
        private float _sensitivityX = 2f;
        private float _sensitivityY = 2f;

        [Header("Look Limits")]
        private MinMax _horizontalLimits = new(-360, 360);
        private MinMax _verticalLimits = new(-80, 90);

        [Header("Debug"), ReadOnly]
        private Vector2 _tempRotation;
        private Vector2 _tempInput { get; set; }
        public Quaternion RotationX { get; private set; }
        public Quaternion RotationY { get; private set; }
        public Quaternion RotationFinal { get; private set; }


        void Start()
        {
             ShowCursor(true, false);
        }

        private float ClampAngle(float angle, float min, float max)
        {
            float newAngle = FixAngle(angle);
            return Mathf.Clamp(newAngle, min, max);
        }

        public void ShowCursor(bool locked, bool visible)
        {
            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = visible;
        }

        public float FixAngle(float angle)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;

            return angle;
        }

        public void Look()
        {
            _tempInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            _tempRotation.x += _tempInput.x * _sensitivityX / 30 * _camera.fieldOfView;
            _tempRotation.y += _tempInput.y * _sensitivityY / 30 * _camera.fieldOfView;

            _tempRotation.x = ClampAngle(_tempRotation.x, _horizontalLimits.RealMin, _horizontalLimits.RealMax);
            _tempRotation.y = ClampAngle(_tempRotation.y, _verticalLimits.RealMin, _verticalLimits.RealMax);

            RotationX = Quaternion.AngleAxis(_tempRotation.x, Vector3.up);
            RotationY = Quaternion.AngleAxis(_tempRotation.y, Vector3.left);
            RotationFinal = RotationX * RotationY;

            _camTransform.rotation = Quaternion.Slerp(_camTransform.rotation, RotationFinal, _smoothTime * _smoothMultiplier * Time.deltaTime);
        }
    }
}
