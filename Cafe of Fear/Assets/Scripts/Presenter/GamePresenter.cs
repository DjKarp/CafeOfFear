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
        [SerializeField] private GameObject _player;

        private MainPerson _mainPerson;

        [Inject]
        public void Counstruct(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;
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
            _cinemaCamera.SetActive(false);
            _player.SetActive(true);
        }

        public void DeactivatePlayer()
        {
            _cinemaCamera.SetActive(true);
            _player.SetActive(false);
        }

        public void StartFinalFear()
        {
            StartCoroutine(FinalFearEffect(() => ShowFinalFear()));
        }

        private IEnumerator FinalFearEffect(Action callback = null)
        {
            for (int i = 1; i < 11; i++)
            {
                _light.SetActive(i%2 == 0);
                yield return new WaitForSeconds(0.08f);
            }

            callback?.Invoke();
        }

        private void ShowFinalFear()
        {
            _mainPerson.gameObject.SetActive(false);
            _vampireTransform.position = _mainPerson.transform.position;
            _finalFear.SetActive(true);
        }
    }
}
