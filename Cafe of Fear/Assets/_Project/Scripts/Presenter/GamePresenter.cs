using System.Collections;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _finalFear;
        [SerializeField] private Transform _vampireTransform;
        [SerializeField] private GameObject _cinemaCamera;

        private GameObject _player;                
        private Visitor _visitor;
        private AudioService _audioService;
        private FadeService _fadeService;
        private LightFlasher _lightFlasher;

        private float _timeWaitBeforeAppearPerson = 15.0f;

        [Inject]
        public void Counstruct(Visitor visitor, AudioService audioService, FadeService fadeService, Player player, LightFlasher lightFlasher)
        {
            _visitor = visitor;
            _audioService = audioService;
            _fadeService = fadeService;
            _player = player.gameObject;
            _lightFlasher = lightFlasher;
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

        public void StartLightFlash()
        {
            DeactivatePlayer();
            _lightFlasher.StartLightFlashing();
        }

        public void StartFinalFear()
        {
            _lightFlasher.StartLightFlashing(true, () => StartCoroutine(FinalFear()));
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
