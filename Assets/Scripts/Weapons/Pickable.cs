using System;
using UnityEngine;

namespace Weapons
{
    public class Pickable : MonoBehaviour
    {
        [SerializeField] private ShootInstance weapon;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BoxCollider bc;
        [SerializeField] private Transform player, gunContainer;
        [SerializeField] private float pickupRange;

        [SerializeField] private bool isEquipped = false;
        private Vector3 distance;

        private void Start()
        {
            if (!isEquipped)
            {
                weapon.enabled = false;
                rb.isKinematic = false;
                bc.isTrigger = false;
            }
        }

        private void Update()
        {
            if (!isEquipped)
            {
                distance = player.position - transform.position;
            }
        }

        public void PickUp()
        {
            if (isEquipped || distance.magnitude > pickupRange) return;

            isEquipped = true;
            rb.isKinematic = true;
            bc.isTrigger = true;
            weapon.enabled = true;

            Transform transform1 = transform;
            transform1.SetParent(gunContainer);
            transform1.localPosition = Vector3.zero;
            transform1.localRotation = Quaternion.Euler(Vector3.zero);
            transform1.localScale = Vector3.one;
        }
    }
}