using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace CafeOfFear
{
    public class MainPerson : MonoBehaviour
    {
        private Transform _transform;
        private SkinnedMeshRenderer _skinnedMesh;

        private AnimationServiceMainNPC _animationService;
        private TextPerson _textNPC;

        private Player _player;
        private PointMainNPC _pointMainNPC;

        private float _startDelay = 5.0f;

        private string _startText = "Give me some \ncoffee, please!";

        public enum StateMainNPC
        {
            None,
            Appeared,
            WalkToPlayer,
            Idle,
            WalkBack
        }

        private StateMainNPC _npcState = StateMainNPC.None;

        [Inject]
        public void Construct(Player player,PointMainNPC pointMainNPC)
        {
            _player = player;
            _pointMainNPC = pointMainNPC;
        }

        private void Awake()
        {
            _transform = gameObject.transform;
            _animationService = GetComponent<AnimationServiceMainNPC>();
            _textNPC = GetComponentInChildren<TextPerson>();
            _skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            _skinnedMesh.enabled = false;
        }

        private void LateUpdate()
        {
            Appeared();
            WalkToPlayer();
            Idle();
        }

        private void Appeared()
        {
            if (_npcState == StateMainNPC.None && _startDelay <= 0.0f)
            {
                if (IsPlayerLookOnNPC())
                {
                    _npcState = StateMainNPC.WalkToPlayer;
                    _skinnedMesh.enabled = true;
                    _animationService.StartWalkToPlayer();
                }
            }
            else
            {
                _startDelay -= Time.deltaTime;
            }
        }

        private void WalkToPlayer()
        {
            if (_npcState == StateMainNPC.WalkToPlayer)
            {
                float distance = Vector3.Distance(_transform.position, _pointMainNPC.Position);
                
                if (distance < 0.5f)
                {
                    _npcState = StateMainNPC.Idle;
                    _animationService.StopWalk();
                    _textNPC.ShowText(_startText);
                }
            }
        }

        private void Idle()
        {
            if (_npcState == StateMainNPC.Idle)
            {
                if (IsPlayerLookOnNPC())
                {
                    Debug.LogError("Look");
                }
            }
        }

        private bool IsPlayerLookOnNPC()
        {
            float angle = Vector3.Angle(_player.PlayerLook, _transform.position - _player.Position);
            
            return angle < 30;
        }
    }
}
