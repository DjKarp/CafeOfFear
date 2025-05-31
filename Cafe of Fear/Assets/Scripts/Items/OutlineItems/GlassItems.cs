using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class GlassItems : OutlineItems
    {
        protected override void ItemFall()
        {
            AudioService.PlayItemSound(AudioService.ItemSound.GlassFalling, gameObject);
        }
    }
}
