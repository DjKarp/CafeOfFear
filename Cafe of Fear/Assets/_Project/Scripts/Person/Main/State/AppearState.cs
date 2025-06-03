using UnityEngine;

namespace CafeOfFear
{
    public class AppearState : IVisitorState
    {
        private Visitor _visitor;
        private float _startDelay = 10.0f;

        public void EnterState(Visitor visitor)
        {
            _visitor = visitor;
        }

        public void UpdateState()
        {
            if (_startDelay <= 0.0f)
            {
                if (_visitor?.SkinnedMesh.enabled == false)
                {
                    _visitor.SkinnedMesh.enabled = true;
                    _startDelay = 2.0f;
                }
                else
                {
                    if (_visitor.IsPlayerLookOnNPC())
                    {
                        _visitor?.ChangeState(new WalkToPlayerState());
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
