using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class PapperCupCap : OutlineItems
    {
        public void DeactivateCollider()
        {
            MeshCollider.enabled = false;
        }
    }
}
