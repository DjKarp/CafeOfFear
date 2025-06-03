using System.Collections;
using UnityEngine;

namespace CafeOfFear
{
    public class WalkToPlayerState : IMainPersonState
    {
        private MainPerson _mainPerson;

        public void EnterState(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;

            _mainPerson?.StartCoroutine(DelayBeforeCinematic());
        }

        public void UpdateState()
        {
            _mainPerson?.PlayerFear();
            float distance = Vector3.Distance(_mainPerson.transform.position, _mainPerson.PointMainNPC.Position);

            if (distance < 0.5f)
            {
                _mainPerson?.ChangeState(new IdleState());
            }
        }

        private IEnumerator DelayBeforeCinematic()
        {
            _mainPerson?.AudioService.PlayPersonSound(AudioService.PersonSound.Appearance);
            _mainPerson?.GamePresenter.StartLightFlash();

            yield return new WaitForSeconds(3.0f);

            _mainPerson?.AnimationService.StartWalkToPlayer();
            _mainPerson?.GamePresenter.StartLightFlash();

            yield return new WaitForSeconds(8.0f);

            _mainPerson?.AudioService.StartPersonWalkToPlayer(_mainPerson?.transform);
        }
    }
}
