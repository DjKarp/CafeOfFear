using UnityEngine;

namespace CafeOfFear
{
    public class WalkBackState : IMainPersonState
    {
        private MainPerson _mainPerson;
        private float _walkBackDistance = 7.4f;

        public void EnterState(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;

            _mainPerson?.GamePresenter.DeactivatePlayer();
            _mainPerson?.AudioService.PlayPersonSound(AudioService.PersonSound.WalkBack);

            if (_mainPerson.IsHappy)
                _mainPerson?.AnimationService.Happy();
            else
                _mainPerson?.AnimationService.WalkBack();
        }

        public void UpdateState()
        {
            float distance = Vector3.Distance(_mainPerson.transform.position, _mainPerson.PointMainNPC.Position);

            _mainPerson?.AudioService.SetPlayerHeartParam(_walkBackDistance / distance);

            if (distance > _walkBackDistance)
            {
                _mainPerson?.AnimationService.StopAnimation();
                _mainPerson?.GamePresenter.StartFinalFear();
                _mainPerson?.ChangeState(null);
            }
        }
    }
}
