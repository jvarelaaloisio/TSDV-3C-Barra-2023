using System;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Windows.Input;
using Random = UnityEngine.Random;

namespace Weapons
{
    public class Pickable : MonoBehaviour
    {
        [SerializeField] private IWeapon weapon;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BoxCollider bc;
        [SerializeField] private Transform player, gunContainer;

        [SerializeField] private float pickupRange;
        [SerializeField] private float dropForwardForce, dropUpwardForce;

        [SerializeField] private bool isEquipped = false;
        private Vector3 distance;
        public static bool slotFull = false;

        private void Start()
        {
            if (!isEquipped)
            {
                weapon.SetEquiped(false);
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

        public void PickAndDrop()
        {
            if (!isEquipped)
            {
                PickUp();
            }
            else if (isEquipped)
            {
                Drop();
            }
        }

        public void PickUp()
        {
            if (isEquipped || distance.magnitude > pickupRange) return;

            isEquipped = true;
            slotFull = true;
            rb.isKinematic = true;
            bc.isTrigger = true;
            //weapon.enabled = true;
            weapon.SetEquiped(true);

            Transform transform1 = transform;
            transform1.SetParent(gunContainer);
            transform1.localPosition = Vector3.zero;
            transform1.localRotation = Quaternion.Euler(Vector3.zero);
            transform1.localScale = Vector3.one;
        }

        private void Drop()
        {
            isEquipped = false;
            slotFull = false;

            rb.isKinematic = false;
            bc.isTrigger = false;

            transform.SetParent(null);
            rb.velocity = player.GetComponent<Rigidbody>().velocity;

            rb.AddForce(player.transform.forward * dropUpwardForce, ForceMode.Impulse);
            rb.AddForce(player.transform.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 3);
            //weapon.enabled = true;
        }
    }
}