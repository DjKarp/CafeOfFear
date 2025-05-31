using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        private CharacterController _characterController;
        private AudioService _audioService;

        private float walkingSpeed = 4.0f;
        private Vector3 moveDirection = Vector3.zero;
        private float _startPositionY;

        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _startPositionY = transform.position.y;
        }
        
        public void Move()
        {            
            if (_inputHandler.Direction.x != 0.0f || _inputHandler.Direction.z != 0.0f)
            {
                _audioService.SetPlayerStepsParam(1.0f);

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
            else
            {
                _audioService.SetPlayerStepsParam(0.0f);
            }

            _audioService.ChangeCamera(true);
        }
    }
}
