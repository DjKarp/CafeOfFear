using UnityEngine;

namespace CafeOfFear
{
    public abstract class InputHandler : MonoBehaviour
    {
        protected Vector3 _direction;
        public Vector3 Direction { get => _direction; }

        public abstract void SetMoveAndRotateDirection();

        private void Update()
        {
            SetMoveAndRotateDirection();
        }
    }
}
