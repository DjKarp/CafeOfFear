using System.Collections;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EntryPoint : MonoBehaviour
    {
        private GamePresenter _gamePresenter;
        private AudioService _audioService;
        private FadeService _fadeService;

        private float _fadeDuration = 3.0f;

        [Inject]
        public void Construct(GamePresenter gamePresenter, AudioService audioService, FadeService fadeService)
        {
            _gamePresenter = gamePresenter;
            _audioService = audioService;
            _fadeService = fadeService;
        }

        private void Start()
        {
            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {
            _fadeService.Init(_fadeDuration);

            yield return new WaitForSeconds(_fadeDuration);

            _gamePresenter.Init();
            _audioService.Init();
        }

        private void OnDisable()
        {

        }
    }
}
