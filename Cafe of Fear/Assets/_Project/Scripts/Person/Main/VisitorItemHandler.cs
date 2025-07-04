using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class VisitorItemReceiver : MonoBehaviour
    {
        [SerializeField] private FloatingDialogueUI _npcDialogueDisplay;
        [SerializeField] private AnimationServiceVisitor _animationService;
        private AudioService _audioService;
        private SignalBus _signalBus;        

        [Inject]
        public void Construct(AudioService audioService, SignalBus signalBus)
        {
            _audioService = audioService;
            _signalBus = signalBus;
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
                    _signalBus.Fire(new GiveCashSignal(papperCup.Cash, this.gameObject));
                }
                else
                {
                    _audioService.PlayPersonSound(AudioService.PersonSound.Bad_Item);
                    _npcDialogueDisplay.ShowBadtext();
                    _animationService.Angry();
                }

                collision.gameObject.SetActive(false);
            }
        }
    }
}
