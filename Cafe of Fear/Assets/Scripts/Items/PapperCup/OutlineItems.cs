using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public class OutlineItems : MonoBehaviour, IPickable
    {
        protected Outline Outline;
        protected Transform Transform;
        protected Rigidbody Rigidbody;
        protected MeshCollider MeshCollider;

        protected virtual void Awake()
        {
            Transform = gameObject.transform;

            Rigidbody = gameObject.GetComponent<Rigidbody>();
            Rigidbody.isKinematic = true;

            MeshCollider = gameObject.GetComponent<MeshCollider>();
            MeshCollider.isTrigger = true;

            Outline = GetComponent<Outline>();
            Outline.enabled = false;
        }

        public virtual void ShowOutline()
        {
            Outline.enabled = true;
        }

        public virtual void HideOutline()
        {
            Outline.enabled = false;
        }

        public virtual void Pick(Transform newParent)
        {
            HideOutline();

            Rigidbody.isKinematic = true;
            MeshCollider.isTrigger = true;

            Transform.parent = newParent;
            Transform.localPosition = Vector3.zero;
            Transform.localRotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }

        public virtual void Drop(Vector3 direction)
        {
            Transform.parent = null;

            Rigidbody.isKinematic = false;
            MeshCollider.isTrigger = false;

            Rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}
