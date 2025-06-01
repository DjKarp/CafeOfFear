using UnityEngine;

namespace CafeOfFear
{
    public class GiveCashSignal
    {
        public float CashValue;
        public GameObject _gameObject;

        public GiveCashSignal (float value, GameObject gameObject)
        {
            CashValue = value;
            _gameObject = gameObject;
        }
    }
}
