using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] public FadeService _fadeService;
        [SerializeField] public FloatingCashDisplay _floatingCashDisplay;

        public override void InstallBindings()
        {
            BindServiceUI();
            BindGiveCashInfo();
        }

        private void BindServiceUI()
        {
            Container
                .Bind<FadeService>()
                .FromInstance(_fadeService)
                .AsSingle();
        }

        private void BindGiveCashInfo()
        {
            Container
                .Bind<FloatingCashDisplay>()
                .FromInstance(_floatingCashDisplay)
                .AsCached();
                
        }
    }
}