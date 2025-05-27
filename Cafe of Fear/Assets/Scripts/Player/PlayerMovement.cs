using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        private float _moveSpeed = 100.0f;

        private Transform _transform;
        private Rigidbody _rigidbody;


        private void Awake()
        {
            _transform = gameObject.transform;
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Move()
        {
            if (_inputHandler.Direction.x != 0.0f || _inputHandler.Direction.z != 0.0f)
            {
                //transform.Translate(_inputHandler.Direction * Time.deltaTime);

                Vector2 velocity = (
                new Vector2(_inputHandler.Direction.x * _transform.right.x, _inputHandler.Direction.x * _transform.right.z)
                + new Vector2(_inputHandler.Direction.z * _transform.forward.x, _inputHandler.Direction.z * _transform.forward.z))
                .normalized * _moveSpeed * Time.deltaTime;

                _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.y);
            }
        }
    }
}
