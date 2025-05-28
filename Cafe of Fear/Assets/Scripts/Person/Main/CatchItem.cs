using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class CatchItem : MonoBehaviour
    {
        [SerializeField] private GiveCash _giveCash;
        [SerializeField] private TextPerson _textNPC;
        [SerializeField] private AnimationServiceMainNPC _animationService;


        private void OnCollisionEnter(Collision collision)
        {
            IPickable pickable = collision.gameObject.GetComponent<IPickable>();

            if (pickable != null)
            {
                PapperCup papperCup = collision.gameObject.GetComponent<PapperCup>();

                if (papperCup != null && papperCup.CupState == PapperCup.PapperCupState.Fill)
                {
                    _giveCash.Show();
                    _animationService.Happy();
                }
                else
                {
                    _textNPC.ShowText("That's not what I asked for!");
                    _animationService.Angry();
                }
            }
        }
    }
}
