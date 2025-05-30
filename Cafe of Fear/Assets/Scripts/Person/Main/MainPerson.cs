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

        private GamePresenter _gamePresenter;

        private float _startDelay = 5.0f;
        private Vector3 _startPosition;

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
        public void Construct(Player player, PointMainNPC pointMainNPC, GamePresenter gamePresenter)
        {
            _player = player;
            _pointMainNPC = pointMainNPC;
            _gamePresenter = gamePresenter;
        }

        private void Awake()
        {
            _transform = gameObject.transform;
            _startPosition = _transform.position;
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
            WalkBack();
        }

        private void Appeared()
        {
            if (_npcState == StateMainNPC.None && _startDelay <= 0.0f)
            {
                if (IsPlayerLookOnNPC())
                {
                    _gamePresenter.StartLightFear();
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
                    _textNPC.ShowText();
                }
            }
        }

        private void Idle()
        {
            if (_npcState == StateMainNPC.Idle)
            {
                if (IsPlayerLookOnNPC())
                {
                    //“€нем голову к игроку;
                }
            }
        }

        private void WalkBack()
        {
            if (_npcState == StateMainNPC.WalkBack)
            {
                float distance = Vector3.Distance(_transform.position, _startPosition);
                Debug.LogError(distance);
                if (distance < 0.9f)
                {
                    _npcState = StateMainNPC.None;
                    _gamePresenter.StartFinalFear();
                }
            }
        }

        public void WalkBackNow(bool isHappy)
        {
            _npcState = StateMainNPC.WalkBack;

            if (isHappy)
                _animationService.Happy();
            else
                _animationService.WalkBack();
        }

        private bool IsPlayerLookOnNPC()
        {
            float angle = Vector3.Angle(_player.PlayerLook, _transform.position - _player.Position);
            
            return angle < 20;
        }
    }
}
