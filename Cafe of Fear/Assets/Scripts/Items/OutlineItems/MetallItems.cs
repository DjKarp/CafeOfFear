using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class MetallItems : OutlineItems
    {
        protected override void ItemFall()
        {
            AudioService.PlayItemSound(AudioService.ItemSound.ForkDropped, gameObject);
        }
    }
}
