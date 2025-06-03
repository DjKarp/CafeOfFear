namespace CafeOfFear
{
    public class IdleState : IVisitorState
    {
        private Visitor _visitor;

        public void EnterState(Visitor visitor)
        {
            _visitor = visitor;

            _visitor?.AudioService.StopPersonWalkToPlayer();
            _visitor?.GamePresenter.ActivatePlayer();
            _visitor?.AnimationService.StopWalk();
            _visitor?.DialogueDisplay.ShowText();
        }

        public void UpdateState()
        {
            _visitor?.PlayerFear();

            if (_visitor.IsPlayerLookOnNPC(true))
            {
                _visitor?.PullingHead.DeactivatePulling();
            }
            else
            {
                _visitor?.PullingHead.ActivatePulling();
            }
        }
    }
}
