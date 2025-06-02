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
