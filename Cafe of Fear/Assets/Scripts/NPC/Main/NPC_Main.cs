using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CafeOfFear
{
    public class NPC_Main : MonoBehaviour
    {
        private Animator _animator;
        private TextNPC _textNPC;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            //_animator.enabled = false;

            _textNPC = GetComponentInChildren<TextNPC>();
        }

        public void StartWalkToPlayer()
        {
            //_animator.enabled = true;
        }

        public void ShowStartText()
        {
            _textNPC.ShowText("Give me some \ncoffee, please!");
        }
    }
}
