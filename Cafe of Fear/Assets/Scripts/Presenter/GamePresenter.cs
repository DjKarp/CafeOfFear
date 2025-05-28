using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _finalFear;
        [SerializeField] private GameObject _light;

        private MainPerson _mainPerson;

        [Inject]
        public void Counstruct(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;
        }

        public void Init()
        {
            _mainPerson.gameObject.SetActive(true);
        }

        public void StartLightFear()
        {
            StartCoroutine(FinalFearEffect());
        }
        public void StartFinalFear()
        {
            StartCoroutine(FinalFearEffect(() => ShowFinalFear()));
        }

        private IEnumerator FinalFearEffect(Action callback = null)
        {
            for (int i = 1; i < 7; i++)
            {
                _light.SetActive(i%2 == 0);
                yield return new WaitForSeconds(0.08f);
            }

            callback?.Invoke();
        }

        private void ShowFinalFear()
        {
            _mainPerson.gameObject.SetActive(false);
            _finalFear.SetActive(true);
        }
    }
}
