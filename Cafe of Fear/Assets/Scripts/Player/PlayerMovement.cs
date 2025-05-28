using UnityEngine;

namespace CafeOfFear
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        private CharacterController _characterController;

        private float walkingSpeed = 4.0f;
        private Vector3 moveDirection = Vector3.zero;
        private float _startPositionY;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _startPositionY = transform.position.y;
        }
        
        public void Move()
        {            
            if (_inputHandler.Direction.x != 0.0f || _inputHandler.Direction.z != 0.0f)
            {
                // Recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                
                float curSpeedX = walkingSpeed * _inputHandler.Direction.z;
                float curSpeedY = walkingSpeed * _inputHandler.Direction.x;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                // Move the controller
                _characterController.Move(moveDirection * Time.deltaTime);

                // Disable fly/jump
                transform.position = new Vector3(transform.position.x, _startPositionY, transform.position.z);
            }
        }
    }
}
