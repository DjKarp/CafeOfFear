using UnityEngine;
using Zenject;
using DG.Tweening;

namespace CafeOfFear
{
    public class PullingHead : MonoBehaviour
    {
        [SerializeField] private Transform _headTransform;
        private AnimationServiceMainNPC _animationService;
        private Player _player;

        private Vector3 _startPosition;
        private Quaternion _startQuaternion;
        private float _durationPullig = 15.0f;
        private bool _isPullingHeagActive = false;

        private Tween _tween;
        private Tween _tweenRotate;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _animationService = GetComponent<AnimationServiceMainNPC>();
        }

        public void ActivatePulling()
        {
            if (_isPullingHeagActive == false)
            {
                _startPosition = _headTransform.position;
                _startQuaternion = _headTransform.rotation;
                _animationService.DeactivateAnimator();
                _isPullingHeagActive = true;

                _tween =
                    _headTransform
                    .DOMove(_player.Position + _player.gameObject.transform.right, _durationPullig);

                _tweenRotate =
                    _headTransform
                    .DOLookAt((_player.Position + _player.gameObject.transform.right) - _headTransform.position, _durationPullig);
            }
        }

        public void DeactivatePulling()
        {
            if (_isPullingHeagActive)
            {
                _animationService.ActivateAnimator();
                _isPullingHeagActive = false;

                _tween.Kill(true);
                _tweenRotate.Kill(true);

                _headTransform.position = _startPosition;
                _headTransform.rotation = _startQuaternion;
            }
        }

        private void OnDisable()
        {
            _tween.Kill(true);
            _tweenRotate.Kill(true);
        }
    }
}
