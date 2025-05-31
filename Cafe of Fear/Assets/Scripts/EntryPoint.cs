using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EntryPoint : MonoBehaviour
    {
        private GamePresenter _gamePresenter;
        private AudioService _audioService;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(GamePresenter gamePresenter, SignalBus signalBus, AudioService audioService)
        {
            _gamePresenter = gamePresenter;
            _signalBus = signalBus;
            _audioService = audioService;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _gamePresenter.Init();
            _audioService.Init();
        }

        private void OnDisable()
        {

        }
    }
}
