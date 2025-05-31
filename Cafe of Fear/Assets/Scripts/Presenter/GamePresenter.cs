using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cinemachine;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _finalFear;
        [SerializeField] private Transform _vampireTransform;
        [SerializeField] private GameObject _light;
        [SerializeField] private GameObject _cinemaCamera;

        private GameObject _player;                
        private MainPerson _mainPerson;
        private AudioService _audioService;
        private UIService _serviceUI;

        [Inject]
        public void Counstruct(MainPerson mainPerson, AudioService audioService, UIService uIService, Player player)
        {
            _mainPerson = mainPerson;
            _audioService = audioService;
            _serviceUI = uIService;
            _player = player.gameObject;
        }

        public void Init()
        {
            StartCoroutine(WaitBeforeAppearPerson());
        }

        private IEnumerator WaitBeforeAppearPerson()
        {
            yield return new WaitForSeconds(1.0f);

            _mainPerson.gameObject.SetActive(true);
        }

        public void StartLightFear()
        {
            DeactivatePlayer();
            StartCoroutine(FinalFearEffect());            
        }

        public void ActivatePlayer()
        {
            _audioService.ChangeCamera(true);
            _cinemaCamera.SetActive(false);
            _player.SetActive(true);
        }

        public void DeactivatePlayer()
        {
            _audioService.ChangeCamera(false);
            _audioService.SetPlayerStepsParam(0.0f);
            _cinemaCamera.SetActive(true);
            _player.SetActive(false);
        }

        public void StartFinalFear()
        {
            StartCoroutine(FinalFearEffect(() => ShowFinalFear()));
        }

        private IEnumerator FinalFearEffect(Action callback = null)
        {
            _audioService.PlayItemSound(AudioService.ItemSound.SoundLight);

            for (int i = 1; i < 17; i++)
            {
                _light.SetActive(i%2 == 0);
                yield return new WaitForSeconds(0.2f);
            }

            callback?.Invoke();
        }

        private void ShowFinalFear()
        {
            _audioService.PlayFinalFearSound(AudioService.FinalFearSound.ChangePerson);
            _audioService.PlayFinalFearSound(AudioService.FinalFearSound.FinalFear);
            _mainPerson.gameObject.SetActive(false);
            _vampireTransform.position = _mainPerson.transform.position;
            _finalFear.SetActive(true);
        }
    }
}
