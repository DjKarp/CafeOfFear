using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private CoffeeFillingPlace _coffeeFillingPlace;
        [SerializeField] private VisitorTargetPoint _visitorTargetPoint;

        public override void InstallBindings()
        {
            BindPositionForNPC();
            BindCoffeeMachine();
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
    }
}