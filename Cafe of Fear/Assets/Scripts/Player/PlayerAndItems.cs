using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class PlayerAndItems : MonoBehaviour
    {
        [SerializeField] private Transform _dragItemPoint;

        private CoffeeFillingPlace _coffeeFillingPlace;

        private IPickable _picketItem;
        private IPickable _takedItem;
        private IFillinable _fillinableItems;

        private AudioService _audioService;

        [Inject]
        public void Construct(CoffeeFillingPlace coffeeFillingPlace, AudioService audioService)
        {
            _coffeeFillingPlace = coffeeFillingPlace;
            _audioService = audioService;
        }

        private void Update()
        {
            if (_picketItem != null && Input.GetMouseButtonDown(0))
            {
                PickItem();
            }

            if (_takedItem != null && Input.GetMouseButtonDown(1))
            {
                DropItem();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_takedItem == null)
            {
                IPickable pickable = other.GetComponent<IPickable>();
                if (pickable == null)
                    pickable = other.GetComponentInParent<IPickable>();

                IFillinable fillinable = other.GetComponent<IFillinable>();

                if (pickable != null && (fillinable == null || fillinable.CupState != PapperCup.PapperCupState.Filling))
                {
                    _fillinableItems = fillinable;

                    if (_picketItem == null)
                    {
                        SetNewPickebleItems(pickable);
                    }
                    else if (_picketItem != pickable)
                    {
                        _picketItem.HideOutline();
                        SetNewPickebleItems(pickable);
                    }                    
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_takedItem == null)
            {
                IPickable pickable = other.GetComponent<IPickable>();
                if (pickable == null)
                    pickable = other.GetComponentInParent<IPickable>();

                if (pickable != null)
                {
                    if (_picketItem == pickable)
                    {
                        _picketItem.HideOutline();
                        _picketItem = null;
                    }
                }
            }
        }

        private void SetNewPickebleItems(IPickable pickable)
        {
            _picketItem = pickable;
            _picketItem.ShowOutline();
        }

        private void PickItem()
        {
            _takedItem = _picketItem;
            _takedItem.Pick(_dragItemPoint);
            _picketItem = null;

            if (_fillinableItems != null && _fillinableItems.CupState == PapperCup.PapperCupState.Fill)
                _coffeeFillingPlace.CoffeCupTake(_fillinableItems);

            _audioService.PlayItemSound(AudioService.ItemSound.PickUp, gameObject);
        }

        public void DropItem()
        {
            _takedItem.Drop(transform.forward * 4.0f);
            _takedItem = null;

            _audioService.PlayItemSound(AudioService.ItemSound.ThrowingObject, gameObject);
        }

        public void ReseaseItem()
        {
            _takedItem.Drop(Vector3.zero);
            _takedItem = null;

            _audioService.PlayItemSound(AudioService.ItemSound.ThrowingObject, gameObject);
        }
        /*
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(_dragItemPoint.position, transform.forward * 5.0f);
        }*/
    }
}
