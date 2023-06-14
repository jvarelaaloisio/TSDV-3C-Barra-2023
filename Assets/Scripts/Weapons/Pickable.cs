using Player;
using UnityEngine;

namespace Weapons
{
    public class Pickable : MonoBehaviour
    {
        private IWeapon weapon;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BoxCollider bc;
        [SerializeField] private Transform player, gunContainer;
        [SerializeField] private WeaponContainer weaponContainer;

        [SerializeField] private float pickupRange;
        [SerializeField] private float dropForwardForce, dropUpwardForce;
        
        [SerializeField] private bool isEquipped = false;
        
        private Vector3 distance;

        private void Start()
        {
            weapon = GetComponent<IWeapon>();
            
            if (!isEquipped)
            {
                weapon.SetEquipped(false);
                rb.isKinematic = false;
                bc.isTrigger = false;
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

        private void PickUp()
        {
            distance = player.position - transform.position;
            if (isEquipped || distance.magnitude > pickupRange) return;
            Transform objectTransform = transform;

            isEquipped = true;
            rb.isKinematic = true;
            bc.isTrigger = true;
            weapon.SetEquipped(true);
            weaponContainer.SetWeapon(weapon);
            
            
            objectTransform.SetParent(gunContainer);
            objectTransform.localPosition = Vector3.zero;
            objectTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        private void Drop()
        {
            isEquipped = false;
            
            rb.isKinematic = false;
            bc.isTrigger = false;

            transform.SetParent(null);
            
            rb.velocity = player.GetComponent<Rigidbody>().velocity;

            rb.AddForce(player.transform.forward * dropUpwardForce, ForceMode.Impulse);
            rb.AddForce(player.transform.up * dropUpwardForce, ForceMode.Impulse);
            
            //float random = Random.Range(-1f, 1f);
            //rb.AddTorque(new Vector3(random, random, random) * 3);
            weapon.SetEquipped(false);
        }
    }
}