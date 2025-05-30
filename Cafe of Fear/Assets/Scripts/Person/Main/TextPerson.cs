using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Zenject;

namespace CafeOfFear
{
    public class TextPerson : MonoBehaviour
    {
        [SerializeField] private string[] _badAnsvert;
        private string _startText = "Give me some \ncoffee, please!";
        private int _badTextNumber = 0;

        private TextMeshPro _textMesh;
        private Sequence _tweenSequence;

        private MainPerson _mainPerson;

        private Vector3 _startPosition;
        private float _duration = 1.0f;

        [Inject]
        public void Construct(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;
        }

        private void Awake()
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _textMesh.gameObject.SetActive(false);

            _startPosition = transform.position;
        }

        public void ShowBadtext()
        {
            if (_badTextNumber < _badAnsvert.Length)
            {
                ShowText(_badAnsvert[_badTextNumber]);
                _badTextNumber++;
            }
            else
            {
                if (_badTextNumber >= _badAnsvert.Length)
                    _mainPerson.WalkBackNow(false);
            }
        }

        public void ShowText(string text = "")
        {
            _textMesh.gameObject.SetActive(true);
            _textMesh.text = text != "" ? text : _startText;

            _tweenSequence = DOTween.Sequence();

            _tweenSequence
                .Append(transform.DOPunchPosition(Vector3.up, _duration, vibrato: 1, elasticity: 0.1f))
                .Append(transform.DOShakeScale(_duration, strength: 0.2f, vibrato: 1, fadeOut: true))
                .OnComplete(() => _textMesh.gameObject.SetActive(false));
        }

        private void OnDisable()
        {
            _tweenSequence.Kill(true);
        }
    }
}
