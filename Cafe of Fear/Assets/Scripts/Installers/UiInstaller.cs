using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] public FadeService _fadeService;
        [SerializeField] public GiveCash _giveCash;

        public override void InstallBindings()
        {
            BindServiceUI();
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
                .Bind<GiveCash>()
                .FromInstance(_giveCash)
                .AsCached();
                
        }
    }
}