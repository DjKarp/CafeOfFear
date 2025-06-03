using System.Collections;
using UnityEngine;

namespace CafeOfFear
{
    public class WalkToPlayerState : IVisitorState
    {
        private Visitor _visitor;

        public void EnterState(Visitor visitor)
        {
            _visitor = visitor;

            _visitor?.StartCoroutine(DelayBeforeCinematic());
        }

        public void UpdateState()
        {
            _visitor?.PlayerFear();
            float distance = Vector3.Distance(_visitor.transform.position, _visitor.VisitorTargetPoint.Position);

            if (distance < 0.5f)
            {
                _visitor?.ChangeState(new IdleState());
            }
        }

        private IEnumerator DelayBeforeCinematic()
        {
            _visitor?.AudioService.PlayPersonSound(AudioService.PersonSound.Appearance);
            _visitor?.GamePresenter.StartLightFlash();

            yield return new WaitForSeconds(3.0f);

            _visitor?.AnimationService.StartWalkToPlayer();
            _visitor?.GamePresenter.StartLightFlash();

            yield return new WaitForSeconds(8.0f);

            _visitor?.AudioService.StartPersonWalkToPlayer(_visitor?.transform);
        }
    }
}
