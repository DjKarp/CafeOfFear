namespace CafeOfFear
{
    public class IdleState : IMainPersonState
    {
        private MainPerson _mainPerson;

        public void EnterState(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;

            _mainPerson?.AudioService.StopPersonWalkToPlayer();
            _mainPerson?.GamePresenter.ActivatePlayer();
            _mainPerson?.AnimationService.StopWalk();
            _mainPerson?.TextNPC.ShowText();
        }

        public void UpdateState()
        {
            _mainPerson?.PlayerFear();

            if (_mainPerson.IsPlayerLookOnNPC(true))
            {
                _mainPerson?.PullingHead.DeactivatePulling();
            }
            else
            {
                _mainPerson?.PullingHead.ActivatePulling();
            }
        }
    }
}
