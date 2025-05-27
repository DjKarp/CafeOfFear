using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class PapperCup : OutlineItems, IFillinable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _cupPlace;

        private PlayerAndItems _playerAndItems;

        public enum PapperCupState
        {
            None,
            Filling,
            Fill
        }

        private PapperCupState _cupState = PapperCupState.None;

        public PapperCupState CupState { get => _cupState; set => _cupState = value; }

        [Inject]
        public void Construct(PlayerAndItems playerAndItems)
        {
            _playerAndItems = playerAndItems;
        }

        public void StartFilling()
        {
            _animator.SetTrigger("isFillingNow");
            _cupState = PapperCupState.Filling;
        }

        public void FinishFilling()
        {
            _cupState = PapperCupState.Fill;
        }

        private void OnTriggerEnter(Collider other)
        {
            PapperCupCap papperCupCap = other.GetComponent<PapperCupCap>();

            if (papperCupCap != null && _cupState == PapperCupState.Fill)
            {
                _playerAndItems.ReseaseItem();
                papperCupCap.DeactivateCollider();
                papperCupCap.Pick(_cupPlace);
            }
        }
    }
}
