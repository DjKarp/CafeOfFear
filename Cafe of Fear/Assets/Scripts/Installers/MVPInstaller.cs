using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class MVPInstaller : MonoInstaller
    {
        [SerializeField] private GamePresenter _gamePresenter;

        [SerializeField] private PlayerAndItems _playerAndItems;
        [SerializeField] private Player _player;

        [SerializeField] private NPC_Main _NPC_Main;

        public override void InstallBindings()
        {
            BindMVP();
            BindPlayer();
            BindNPC();
        }

        private void BindMVP()
        {
            Container
                .Bind<GamePresenter>()
                .FromInstance(_gamePresenter)
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container
                .Bind<Player>()
                .FromInstance(_player)
                .AsSingle();

            Container
                .Bind<PlayerAndItems>()
                .FromInstance(_playerAndItems)
                .AsSingle();
        }

        private void BindNPC()
        {
            Container
                .Bind<NPC_Main>()
                .FromInstance(_NPC_Main)
                .AsSingle();
        }
    }
}