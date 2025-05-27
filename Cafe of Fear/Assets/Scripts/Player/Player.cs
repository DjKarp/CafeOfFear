using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;

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
    }
}
