using System.Collections;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _finalFear;
        [SerializeField] private Transform _vampireTransform;
        [SerializeField] private GameObject _light;
        [SerializeField] private GameObject _cinemaCamera;

        private GameObject _player;                
        private Visitor _visitor;
        private AudioService _audioService;
        private FadeService _fadeService;

        private float _timeWaitBeforeAppearPerson = 15.0f;

        [Inject]
        public void Counstruct(Visitor visitor, AudioService audioService, FadeService fadeService, Player player)
        {
            _visitor = visitor;
            _audioService = audioService;
            _fadeService = fadeService;
            _player = player.gameObject;
        }

        public void Init()
        {
            StartCoroutine(WaitBeforeAppearPerson());
        }

        private IEnumerator WaitBeforeAppearPerson()
        {
            yield return new WaitForSeconds(_timeWaitBeforeAppearPerson);

            _visitor.gameObject.SetActive(true);
        }

        public void StartLightFlash()
        {
            DeactivatePlayer();
            StartCoroutine(LightFlash());            
        }

        public void ActivatePlayer()
        {
            _fadeService.ShowCursor();
            _audioService.ChangeCamera(true);
            _cinemaCamera.SetActive(false);
            _player.SetActive(true);
        }

        public void DeactivatePlayer()
        {
            _fadeService.HideCursor();
            _audioService.ChangeCamera(false);
            _audioService.SetPlayerStepsParam(0.0f);
            _cinemaCamera.SetActive(true);
            _player.SetActive(false);
        }

        public void StartFinalFear()
        {
            StartCoroutine(LightFlash(true));
        }

        private IEnumerator LightFlash(bool isFinal = false)
        {
            _audioService.PlayItemSound(AudioService.ItemSound.SoundLight);
            int lightFlashCount = isFinal ? 9 : 15;

            for (int i = 1; i < lightFlashCount; i++)
            {
                _light.SetActive(i%2 == 0);
                yield return new WaitForSeconds(0.2f);
            }

            if (isFinal)
                StartCoroutine(FinalFear());
        }

        private IEnumerator FinalFear()
        {
            _audioService.PlayFinalFearSound(AudioService.FinalFearSound.ChangePerson);
            _audioService.PlayFinalFearSound(AudioService.FinalFearSound.FinalFear);
            _visitor.gameObject.SetActive(false);
            _vampireTransform.position = _visitor.transform.position;
            _finalFear.SetActive(true);

            yield return new WaitForSeconds(5.0f);

            _fadeService.Finish();
        }
    }
}
