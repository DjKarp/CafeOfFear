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
        protected Collider ColliderChild;

        protected virtual void Awake()
        {
            Transform = gameObject.transform;

            Rigidbody = gameObject.GetComponent<Rigidbody>();
            Rigidbody.isKinematic = true;

            MeshCollider = gameObject.GetComponent<MeshCollider>();
            ColliderChild = gameObject.GetComponentInChildren<Collider>();
            ChangeCollider(true);

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
            ChangeCollider(true);

            Transform.parent = newParent;
            Transform.localPosition = Vector3.zero;
            Transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        public virtual void Drop(Vector3 direction)
        {
            Transform.parent = null;

            Rigidbody.isKinematic = false;
            ChangeCollider(false);

            if (direction != Vector3.zero)
                Rigidbody.AddForce(direction, ForceMode.Impulse);
        }

        private void ChangeCollider(bool isActive)
        {
            if (MeshCollider != null)
                MeshCollider.isTrigger = isActive;

            if (ColliderChild != null)
                ColliderChild.isTrigger = isActive;
        }
    }
}
