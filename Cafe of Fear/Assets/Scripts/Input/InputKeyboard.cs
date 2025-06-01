using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class InputKeyboard : InputHandler
    {
        public override void SetMoveAndRotateDirection()
        {            
            _direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}
