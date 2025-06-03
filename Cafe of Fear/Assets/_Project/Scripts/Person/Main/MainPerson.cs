using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class MainPerson : MonoBehaviour
    {
        public SkinnedMeshRenderer SkinnedMesh { get; private set; }
        public AnimationServiceMainNPC AnimationService { get; private set; }
        public TextPerson TextNPC { get; private set; }
        public PullingHead PullingHead { get; private set; }        
        public PointMainNPC PointMainNPC { get; private set; }
        public GamePresenter GamePresenter { get; private set; }
        public AudioService AudioService { get; private set; }
        public bool IsHappy { get; private set; }

        private Player _player;
        private SignalBus _signalBus;
        private IMainPersonState _currentState;

        [Inject]
        public void Construct(Player player, PointMainNPC pointMainNPC, GamePresenter gamePresenter, AudioService audioService, SignalBus signalBus)
        {
            _player = player;
            PointMainNPC = pointMainNPC;
            GamePresenter = gamePresenter;
            AudioService = audioService;
            _signalBus = signalBus;
        }

        private void Awake()
        {
            AnimationService = GetComponent<AnimationServiceMainNPC>();
            TextNPC = GetComponentInChildren<TextPerson>();
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

        public void ChangeState(IMainPersonState mainPersonState)
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
