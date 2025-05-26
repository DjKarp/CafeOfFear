using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EntryPoint : MonoBehaviour
    {
        private GamePresenter _gamePresenter;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(GamePresenter gamePresenter, SignalBus signalBus)
        {
            _gamePresenter = gamePresenter;
            _signalBus = signalBus;
        }

        private void Awake()
        {

        }

        private void StartGame()
        {
            _gamePresenter.Init();
        }

        private void OnDisable()
        {

        }
    }
}
