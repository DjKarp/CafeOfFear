using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class MVPInstaller : MonoInstaller
    {
        [SerializeField] private PlayerAndItems _playerAndItems;
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerAndItems>()
                .FromInstance(_playerAndItems)
                .AsSingle();
        }
    }
}