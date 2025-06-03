using UnityEngine;

namespace CafeOfFear
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        [SerializeField] private PlayerLook _playerLook;

        public Vector3 Position { get => transform.position; }
        public Vector3 PlayerVectorForward { get => _playerLook.PlayerVectorForward; }

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerLook = GetComponent<PlayerLook>();
        }

        private void FixedUpdate()
        {
            _playerLook.Look();
            _playerMovement.Move();
        }
        /*
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Position, PlayerLook * 2.0f);
        }*/
    }
}
