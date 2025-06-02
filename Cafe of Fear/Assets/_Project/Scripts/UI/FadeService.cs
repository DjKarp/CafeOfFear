using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CafeOfFear
{
    public class FadeService : MonoBehaviour
    {
        [SerializeField] private Image _cursorImage;
        [SerializeField] private Image _fadeText;
        private Image _fadeImage;
        private float _fadeDuration = 2.0f;

        private Sequence _sequence;

        private void Awake()
        {
            _fadeImage = GetComponent<Image>();
            _fadeImage.enabled = true;
            _cursorImage.enabled = false;
        }

        public void Init(float duration)
        {
            _fadeDuration = duration;
            _sequence = DOTween.Sequence();

            _sequence
                .Append( 
                    _fadeImage
                    .DOFade(0.0f, _fadeDuration)
                    .From(1.0f)
                    .SetEase(Ease.InQuint)
                    .OnComplete(() => ShowCursor()));
        }

        public void Finish()
        {
            _sequence = DOTween.Sequence();
            
            _sequence
                .Append(
                    _fadeImage
                    .DOFade(1.0f, _fadeDuration)
                    .From(0.0f))
                .Append(
                    _fadeText
                    .DOFade(1.0f, _fadeDuration)
                    .From(0.0f));
        }

        public void ShowCursor()
        {
            _cursorImage.enabled = true;
        }

        public void HideCursor()
        {
            _cursorImage.enabled = false;
        }

        private void OnDestroy()
        {
            _sequence.Kill(true);
        }
    }
}
