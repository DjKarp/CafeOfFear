using UnityEngine;

namespace CafeOfFear
{
    public class VisitorTargetPoint : MonoBehaviour
    {
        private Transform _transform;

        public Vector3 Position { get => _transform.position; }

        private void Awake()
        {
            _transform = gameObject.transform;
        }
    }
}
