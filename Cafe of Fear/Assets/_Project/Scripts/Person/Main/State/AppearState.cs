using UnityEngine;

namespace CafeOfFear
{
    public class AppearState : IMainPersonState
    {
        private MainPerson _mainPerson;
        private float _startDelay = 10.0f;

        public void EnterState(MainPerson mainPerson)
        {
            _mainPerson = mainPerson;
        }

        public void UpdateState()
        {
            if (_startDelay <= 0.0f)
            {
                if (_mainPerson?.SkinnedMesh.enabled == false)
                {
                    _mainPerson.SkinnedMesh.enabled = true;
                    _startDelay = 2.0f;
                }
                else
                {
                    if (_mainPerson.IsPlayerLookOnNPC())
                    {
                        _mainPerson?.ChangeState(new WalkToPlayerState());
                    }
                }
            }
            else
            {
                _startDelay -= Time.deltaTime;
            }
        }
    }
}
