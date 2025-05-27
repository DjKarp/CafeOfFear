using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace CafeOfFear
{
    public class TextNPC : MonoBehaviour
    {
        private TextMeshPro _textMesh;
        private Sequence _tweenSequence;

        private Vector3 _startPosition;
        private float _duration = 1.0f;

        private void Awake()
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _textMesh.gameObject.SetActive(false);

            _startPosition = transform.position;
        }

        public void ShowText(string text)
        {
            _textMesh.gameObject.SetActive(true);
            _textMesh.text = text;

            _tweenSequence = DOTween.Sequence();

            _tweenSequence
                .Append(transform.DOPunchPosition(Vector3.up, _duration, vibrato: 1, elasticity: 0.1f))
                .AppendInterval(5.0f)
                .Append(transform.DOShakeScale(_duration, strength: 0.2f, vibrato: 1, fadeOut: true))
                .OnComplete(() => _textMesh.gameObject.SetActive(false));
        }

        private void OnDisable()
        {
            _tweenSequence.Kill(true);
        }
    }
}
