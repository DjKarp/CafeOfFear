using System.Collections;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace CafeOfFear
{
    public class EntryPoint : MonoBehaviour
    {
        private const string BootstrapSceneName = "Bootstrap";

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

            while(true)
            {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    SceneManager.LoadScene(BootstrapSceneName);
                }

                yield return new WaitForEndOfFrame();
            }
        }

        private void OnDisable()
        {

        }
    }
}
