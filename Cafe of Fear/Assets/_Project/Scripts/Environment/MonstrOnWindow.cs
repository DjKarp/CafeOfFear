using System.Collections;
using UnityEngine;

namespace CafeOfFear
{
    public class MonstrOnWindow : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _bodyMeshRenderer;
        private float _timeFlash = 10.0f;
        private float _timeShow = 1.0f;
        private float _timer;

        private void Awake()
        {
            DeactivateVampire();            
        }

        private void Start()
        {
            StartCoroutine(FlashVampireOnWindow());
        }

        private void SetTimer()
        {
            _timer = Random.Range(_timeFlash / 2.0f, _timeFlash * 1.5f);
        }

        private void DeactivateVampire()
        {
            _bodyMeshRenderer.enabled = false;
        }

        private void ActivateVampire()
        {
            _bodyMeshRenderer.enabled = true;
        }

        private IEnumerator FlashVampireOnWindow()
        {
            while(true)
            {
                SetTimer();

                yield return new WaitForSeconds(_timer);

                ActivateVampire();

                yield return new WaitForSeconds(_timeShow);

                DeactivateVampire();
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
