using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private CoffeeFillingPlace _coffeeFillingPlace;
        [SerializeField] private VisitorTargetPoint _visitorTargetPoint;
        [SerializeField] private LightFlasher _lightFlasher;

        public override void InstallBindings()
        {
            BindPositionForNPC();
            BindCoffeeMachine();
            BindLightServices();
        }

        private void BindPositionForNPC()
        {
            Container
                .Bind<VisitorTargetPoint>()
                .FromInstance(_visitorTargetPoint)
                .AsCached();
        }

        private void BindCoffeeMachine()
        {
            Container
                .Bind<CoffeeFillingPlace>()
                .FromInstance(_coffeeFillingPlace)
                .AsSingle();
        }

        private void BindLightServices()
        {
            Container
                .Bind<LightFlasher>()
                .FromInstance(_lightFlasher)
                .AsSingle();
        }
    }
}