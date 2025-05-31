using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioService _audioService;

        public override void InstallBindings()
        {
            BindAudioService();
        }

        private void BindAudioService()
        {
            Container
                .Bind<AudioService>()
                .FromInstance(_audioService)
                .AsSingle();
        }
    }
}