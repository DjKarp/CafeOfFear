using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class CoffeeFillingPlace : MonoBehaviour
    {
        private PlayerAndItems _playerAndItems;

        private Transform _transform;
        private IFillinable _fillinableItem;
        private IPickable _pickableItem;

        [Inject]
        public void Construct(PlayerAndItems playerAndItems)
        {
            _playerAndItems = playerAndItems;
        }

        private void Awake()
        {
            _transform = gameObject.transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_fillinableItem == null)
            {
                IFillinable fillinable = other.gameObject.GetComponent<IFillinable>();
                IPickable pickable = other.gameObject.GetComponent<IPickable>();

                if (fillinable != null && fillinable.CupState == PapperCup.PapperCupState.None)
                {
                    _playerAndItems.ReseaseItem();

                    _pickableItem = pickable;
                    _pickableItem.Pick(_transform);

                    _fillinableItem = fillinable;
                    _fillinableItem.StartFilling();
                }
            }
        }
    }
}
