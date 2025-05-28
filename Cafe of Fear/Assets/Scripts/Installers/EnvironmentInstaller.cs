using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private CoffeeFillingPlace _coffeeFillingPlace;
        [SerializeField] private PointMainNPC _positionMainNPC;

        public override void InstallBindings()
        {
            BindPositionForNPC();
            BindCoffeeMachine();
        }

        private void BindPositionForNPC()
        {
            Container
                .Bind<PointMainNPC>()
                .FromInstance(_positionMainNPC)
                .AsCached();
        }

        private void BindCoffeeMachine()
        {
            Container
                .Bind<CoffeeFillingPlace>()
                .FromInstance(_coffeeFillingPlace)
                .AsSingle();
        }
    }
}