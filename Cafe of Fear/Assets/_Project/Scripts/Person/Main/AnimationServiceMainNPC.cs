using System.Collections;
using UnityEngine;

namespace CafeOfFear
{
    public class AnimationServiceMainNPC : MonoBehaviour
    {
        private Animator _animator;

        private string _walkParams = "walk";
        private string _angryParams = "isAngry";
        private string _happyParams = "isHappy";

        private float _walkAnim = 1.0f;
        private float _idleAnim = 0.0f;
        private float _backWaltAnim = -1.0f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animator.enabled = false;
        }

        public void StartWalkToPlayer()
        {
            _animator.enabled = true;
            _animator.SetFloat(_walkParams, _walkAnim);
        }

        public void StopWalk()
        {
            _animator.SetFloat(_walkParams, _idleAnim);
        }

        public void Angry()
        {
            _animator.SetBool(_angryParams, true);
            StartCoroutine(ResetValue());
        }

        public void WalkBack()
        {
            _animator.SetFloat(_walkParams, _backWaltAnim);
        }

        public void Happy()
        {
            _animator.SetBool(_happyParams, true);
            StartCoroutine(ResetValue());
        }

        public void StopAnimation()
        {
            _animator.speed = 0;
        }

        public IEnumerator ResetValue()
        {
            yield return new WaitForSeconds(20.0f);

            _animator.SetBool(_angryParams, false);
            _animator.SetBool(_happyParams, false);
        }

        public void ActivateAnimator()
        {
            _animator.enabled = true;
        }

        public void DeactivateAnimator()
        {
            _animator.enabled = false;
        }
    }
}
