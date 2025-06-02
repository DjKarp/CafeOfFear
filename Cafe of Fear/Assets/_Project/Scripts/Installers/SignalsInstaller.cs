using Zenject;

namespace CafeOfFear
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindGameplaySignals();
        }

        private void BindGameplaySignals()
        {
            Container
                .DeclareSignal<GiveCashSignal>()
                .OptionalSubscriber();
        }
    }
}