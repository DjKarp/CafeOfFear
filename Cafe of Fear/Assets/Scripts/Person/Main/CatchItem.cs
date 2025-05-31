using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class CatchItem : MonoBehaviour
    {
        [SerializeField] private GiveCash _giveCash;
        [SerializeField] private TextPerson _textNPC;
        [SerializeField] private AnimationServiceMainNPC _animationService;
        private MainPerson _mainPerson;
        private AudioService _audioService;

        [Inject]
        public void Construct(MainPerson mainPerson, AudioService audioService)
        {
            _mainPerson = mainPerson;
            _audioService = audioService;
        }


        private void OnCollisionEnter(Collision collision)
        {
            IPickable pickable = collision.gameObject.GetComponent<IPickable>();

            if (pickable != null)
            {
                PapperCup papperCup = collision.gameObject.GetComponent<PapperCup>();

                if (papperCup != null && papperCup.CupState == PapperCup.PapperCupState.Fill)
                {
                    _audioService.PlayPersonSound(AudioService.PersonSound.Take_Coffee);
                    _audioService.PlayItemSound(AudioService.ItemSound.Cash);
                    _giveCash.Show();
                    _mainPerson.WalkBackNow(true);
                }
                else
                {
                    _audioService.PlayPersonSound(AudioService.PersonSound.Bad_Item);
                    _textNPC.ShowBadtext();
                    _animationService.Angry();
                }

                collision.gameObject.SetActive(false);
            }
        }
    }
}
