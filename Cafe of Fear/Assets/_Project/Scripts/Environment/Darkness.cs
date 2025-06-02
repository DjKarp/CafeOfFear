using UnityEngine;
using DG.Tweening;

namespace CafeOfFear
{
    public class Darkness : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private Tween _tween;
        private float _duration = 60;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            _tween =
                _meshRenderer.material
                .DOFade(0.9f, _duration)
                .From(0.0f);
        }

        private void OnDisable()
        {
            _tween.Kill(true);
        }
    }
}
