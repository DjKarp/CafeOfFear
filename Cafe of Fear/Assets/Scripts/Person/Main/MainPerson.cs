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

        public enum StateMainNPC
        {
            None,
            Appeared,
            WalkToPlayer,
            Idle,
            WalkBack
        }

        public StateMainNPC NpcState = StateMainNPC.None;

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
            if (NpcState == StateMainNPC.None && _startDelay <= 0.0f)
            {
                if (IsPlayerLookOnNPC())
                {
                    
                    NpcState = StateMainNPC.WalkToPlayer;
                    _skinnedMesh.enabled = true;                    
                    StartCoroutine(DelayBeforeCinematic());
                }
            }
            else
            {
                _startDelay -= Time.deltaTime;
            }
        }

        private IEnumerator DelayBeforeCinematic()
        {
            yield return new WaitForSeconds(2.0f);

            _animationService.StartWalkToPlayer();
            _gamePresenter.StartLightFear();
        }

        private void WalkToPlayer()
        {
            if (NpcState == StateMainNPC.WalkToPlayer)
            {
                float distance = Vector3.Distance(_transform.position, _pointMainNPC.Position);
                
                if (distance < 0.5f)
                {
                    _gamePresenter.ActivatePlayer();
                    NpcState = StateMainNPC.Idle;
                    _animationService.StopWalk();
                    _textNPC.ShowText();
                }
            }
        }

        private void Idle()
        {
            if (NpcState == StateMainNPC.Idle)
            {
                if (IsPlayerLookOnNPC())
                {
                    //“€нем голову к игроку;
                }
            }
        }

        private void WalkBack()
        {
            if (NpcState == StateMainNPC.WalkBack)
            {
                float distance = Vector3.Distance(_transform.position, _pointMainNPC.Position);
                if (distance > 7.4f)
                {
                    _animationService.StopAnimation();
                    NpcState = StateMainNPC.None;
                    _gamePresenter.StartFinalFear();
                }
            }
        }

        public void WalkBackNow(bool isHappy)
        {
            NpcState = StateMainNPC.WalkBack;
            _gamePresenter.DeactivatePlayer();

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
