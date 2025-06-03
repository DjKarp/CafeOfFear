using UnityEngine;

namespace CafeOfFear
{
    public class WalkBackState : IVisitorState
    {
        private Visitor _visitor;
        private float _walkBackDistance = 7.4f;

        public void EnterState(Visitor visitor)
        {
            _visitor = visitor;

            _visitor?.GamePresenter.DeactivatePlayer();
            _visitor?.AudioService.PlayPersonSound(AudioService.PersonSound.WalkBack);

            if (_visitor.IsHappy)
                _visitor?.AnimationService.Happy();
            else
                _visitor?.AnimationService.WalkBack();
        }

        public void UpdateState()
        {
            float distance = Vector3.Distance(_visitor.transform.position, _visitor.VisitorTargetPoint.Position);

            _visitor?.AudioService.SetPlayerHeartParam(_walkBackDistance / distance);

            if (distance > _walkBackDistance)
            {
                _visitor?.AnimationService.StopAnimation();
                _visitor?.GamePresenter.StartFinalFear();
                _visitor?.ChangeState(null);
            }
        }
    }
}
