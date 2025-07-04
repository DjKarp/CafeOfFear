using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class CoffeeFillingPlace : MonoBehaviour
    {
        private BoxCollider _boxCollider;

        private PlayerAndItems _playerAndItems;
        private AudioService _audioService;

        private IFillinable _fillinableItem;
        private IPickable _pickableItem;

        [Inject]
        public void Construct(PlayerAndItems playerAndItems, AudioService audioService)
        {
            _playerAndItems = playerAndItems;
            _audioService = audioService;
        }

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_fillinableItem == null)
            {
                IFillinable fillinable = other.gameObject.GetComponent<IFillinable>();
                IPickable pickable = other.gameObject.GetComponent<IPickable>();

                if (fillinable != null && fillinable.CupState == PapperCup.PapperCupState.None)
                {
                    _audioService.PlayItemSound(AudioService.ItemSound.Install_Cup);
                    _boxCollider.enabled = false;

                    _playerAndItems.ReseaseItem();

                    _pickableItem = pickable;
                    _pickableItem.Pick(gameObject.transform);

                    _fillinableItem = fillinable;
                    _fillinableItem.StartFilling();
                }
            }
        }

        public void CoffeCupTake(IFillinable fillinable)
        {
            if (fillinable == _fillinableItem)
            {
                _fillinableItem = null;
                _boxCollider.enabled = true;
            }
        }
    }
}
