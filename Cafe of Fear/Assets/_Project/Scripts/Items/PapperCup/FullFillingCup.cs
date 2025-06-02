using UnityEngine;

namespace CafeOfFear
{
    public class FullFillingCup : MonoBehaviour
    {
        [SerializeField] PapperCup _papperCup;

        // Invoke from Animations "CreateCoffee". Create for Example.
        public void FullFilling()
        {
            _papperCup.FinishFilling();
        }
    }
}
