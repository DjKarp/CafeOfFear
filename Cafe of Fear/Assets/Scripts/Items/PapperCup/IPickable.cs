using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public interface IPickable
    {
        public void ShowOutline();
        public void HideOutline();
        public void Pick(Transform newParent);
        public void Drop(Vector3 direction);
    }
}
