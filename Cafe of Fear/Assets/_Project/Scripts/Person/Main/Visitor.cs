using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class Visitor : MonoBehaviour
    {
        public SkinnedMeshRenderer SkinnedMesh { get; private set; }
        public AnimationServiceVisitor AnimationService { get; private set; }
        public FloatingDialogueUI DialogueDisplay { get; private set; }
        public PullingHead PullingHead { get; private set; }        
        public VisitorTargetPoint VisitorTargetPoint { get; private set; }
        public GamePresenter GamePresenter { get; private set; }
        public AudioService AudioService { get; private set; }
        public bool IsHappy { get; private set; }

        private Player _player;
        private SignalBus _signalBus;
        private IVisitorState _currentState;

        [Inject]
        public void Construct(Player player, VisitorTargetPoint visitorTargetPoint, GamePresenter gamePresenter, AudioService audioService, SignalBus signalBus)
        {
            _player = player;
            VisitorTargetPoint = visitorTargetPoint;
            GamePresenter = gamePresenter;
            AudioService = audioService;
            _signalBus = signalBus;
        }

        private void Awake()
        {
            AnimationService = GetComponent<AnimationServiceVisitor>();
            DialogueDisplay = GetComponentInChildren<FloatingDialogueUI>();
            SkinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            SkinnedMesh.enabled = false;
            PullingHead = GetComponent<PullingHead>();

            _signalBus.Subscribe<GiveCashSignal>(WalkBackNow);
        }

        private void OnEnable()
        {
            ChangeState(new AppearState());
        }

        private void LateUpdate()
        {
            _currentState?.UpdateState();
        }

        public void ChangeState(IVisitorState mainPersonState)
        {
            _currentState = mainPersonState;
            _currentState?.EnterState(this);
        }

        public void WalkBackNow(GiveCashSignal giveCashSignal)
        {
            IsHappy = giveCashSignal.CashValue > 0.0f;
            ChangeState(new WalkBackState());
        }

        public bool IsPlayerLookOnNPC(bool isPulling = false)
        {
            Vector3 personToPlayerVector = transform.position - _player.Position;

            float angle = Vector3.Angle(
                new Vector3(_player.PlayerVectorForward.x, 0.0f, _player.PlayerVectorForward.z).normalized,
                new Vector3(personToPlayerVector.x, 0.0f, personToPlayerVector.z).normalized
                );

            return angle < (isPulling ? 45 : 20);
        }

        public void PlayerFear()
        {
            float angle = Vector3.Angle(_player.PlayerVectorForward, transform.position - _player.Position);

            AudioService.SetPlayerHeartParam(angle / 180);
        }
    }
}
