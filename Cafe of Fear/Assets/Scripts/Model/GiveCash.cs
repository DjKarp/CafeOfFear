using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace CafeOfFear
{
    public class GiveCash : MonoBehaviour
    {
        [SerializeField] private Transform _backgroundTransform;
        [SerializeField] private TextMeshPro _textMeshPro;

        private Vector3 _startPosition;
        private Vector3 _endPosition;

        private Vector3 _startScale;

        private float _duration = 4.0f;

        private Sequence _tweenSequence;

        private void Awake()
        {
            _backgroundTransform.gameObject.SetActive(false);

            _startScale = _backgroundTransform.localScale;

            _startPosition = transform.position;
            _endPosition = _startPosition + new Vector3(0.0f, 0.5f, 0.0f);
        }

        public void Show()
        {
            _backgroundTransform.gameObject.SetActive(true);

            _tweenSequence = DOTween.Sequence();

            _tweenSequence
                .Append(transform.DOMoveY(_endPosition.y, _duration))
                .Insert(0, _backgroundTransform.DOScale(_startScale, _duration).From(Vector3.zero))
                .AppendInterval(_duration / 3.0f)
                .Append(_backgroundTransform.DOScale(Vector3.zero, _duration / 3.0f))
                .OnComplete(() => Hide());
        }

        public void Hide()
        {
            _tweenSequence.Kill(true);
            _backgroundTransform.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _tweenSequence.Kill(true);
        }
    }
}
