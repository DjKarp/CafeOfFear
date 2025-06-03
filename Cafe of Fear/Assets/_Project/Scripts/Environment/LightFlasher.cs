using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class LightFlasher : MonoBehaviour
    {
        [SerializeField] private GameObject _lightParentGameObject;
        private AudioService _audioService;

        [Inject]
        public void Counstruct(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void StartLightFlashing(bool isFinal = false, Action callback = null)
        {
            StartCoroutine(LightFlash(isFinal, callback));
        }

        private IEnumerator LightFlash(bool isFinal = false, Action callback = null)
        {
            _audioService.PlayItemSound(AudioService.ItemSound.SoundLight);
            int lightFlashCount = isFinal ? 9 : 15;

            for (int i = 1; i < lightFlashCount; i++)
            {
                _lightParentGameObject.SetActive(i % 2 == 0);
                yield return new WaitForSeconds(0.2f);
            }

            if (isFinal)
                callback?.Invoke();
        }
    }
}
