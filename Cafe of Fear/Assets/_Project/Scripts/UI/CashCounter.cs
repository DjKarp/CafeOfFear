using TMPro;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class CashCounter : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        private float _cash = 0.0f;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
            AddedCash(Random.Range(0.5f, 9.9f));

            _signalBus.Subscribe<GiveCashSignal>(AddedCash);
        }

        private void AddedCash(GiveCashSignal giveCashSignal)
        {
            AddedCash(giveCashSignal.CashValue);
        }

        private void AddedCash(float value)
        {
            _cash += value;
            _textMesh.text = string.Format("{0:0.0} $", _cash);
        }
    }
}
