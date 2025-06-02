using UnityEngine;
using TMPro;
using DG.Tweening;
using Zenject;

namespace CafeOfFear
{
    public class GiveCash : MonoBehaviour
    {
        [SerializeField] private Transform _backgroundTransform;
        private TextMeshPro _textMeshPro;
        private Sequence _tweenSequence;

        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private Vector3 _startScale;

        private Vector3 _showOffsetPosition = new Vector3(0.3f, 0.6f, 0.0f);
        private float _duration = 1.0f;        

        private AudioService _audioService;
        private Player _player;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(AudioService audioService, SignalBus signalBus, Player player)
        {
            _audioService = audioService;
            _signalBus = signalBus;
            _player = player;
        }

        private void Awake()
        {
            _textMeshPro = GetComponentInChildren<TextMeshPro>();            
            _startScale = _backgroundTransform.localScale;

            Hide();

            _signalBus.Subscribe<GiveCashSignal>(AddedCash);
        }

        private void Show()
        {
            _backgroundTransform.gameObject.SetActive(true);
            _textMeshPro.enabled = true;

            _tweenSequence = DOTween.Sequence();

            _tweenSequence
                .Append(transform.DOMoveY(_endPosition.y, _duration))
                .Insert(0, _backgroundTransform.DOScale(_startScale, _duration).From(Vector3.zero))
                .AppendCallback(() => _audioService.PlayItemSound(AudioService.ItemSound.Cash, gameObject))
                .Append(_backgroundTransform.DOScale(Vector3.zero, 1.0f))
                .OnComplete(() => Hide());
        }

        public void Hide()
        {
            _tweenSequence.Kill(true);
            _backgroundTransform.gameObject.SetActive(false);
            _textMeshPro.enabled = false;
        }

        private void AddedCash(GiveCashSignal giveCashSignal)
        {
            transform.position = _startPosition = giveCashSignal._gameObject.transform.position + _showOffsetPosition;
            _endPosition = _startPosition + new Vector3(0.0f, 0.5f, 0.0f);

            AddedCash(giveCashSignal.CashValue);
        }

        private void AddedCash(float value)
        {
            _textMeshPro.text = string.Format("$ {0:0.0}", value);
            Show();
        }

        private void OnDisable()
        {
            _tweenSequence.Kill(true);
        }
    }
}
