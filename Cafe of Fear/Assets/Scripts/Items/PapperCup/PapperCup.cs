using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class PapperCup : OutlineItems, IFillinable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _cupPlace;

        public enum PapperCupState
        {
            None,
            Filling,
            Fill
        }

        private PapperCupState _cupState = PapperCupState.None;

        public PapperCupState CupState { get => _cupState; set => _cupState = value; }

        protected override void Awake()
        {
            base.Awake();            
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
                papperCupCap.Pick(_cupPlace);
            }
        }
    }
}
