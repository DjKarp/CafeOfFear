using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private CoffeeFillingPlace _coffeeFillingPlace;

        public override void InstallBindings()
        {
            BindCoffeeMachine();
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