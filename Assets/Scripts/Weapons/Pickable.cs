using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class Pickable : MonoBehaviour
    {
        private IWeapon weapon;
        private Rigidbody itemBody;
        private BoxCollider itemCollider;
        [SerializeField] private Transform gunContainer;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private WeaponContainer weaponContainer;

        [SerializeField] private float pickupRange;
        [SerializeField] private float dropForwardForce, dropUpwardForce;

        [SerializeField] private bool isEquipped = false;

        private Vector3 distance;

        private void Start()
        {
            weapon = GetComponent<IWeapon>();
            itemBody = GetComponent<Rigidbody>();
            itemCollider = GetComponent<BoxCollider>();

            if (!isEquipped)
            {
                weapon.SetEquiped(false);
                itemBody.isKinematic = false;
                itemCollider.isTrigger = false;
            }
        }

        private void Update()
        {
            if (!isEquipped)
            {
                distance = playerTransform.position - transform.position;
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
            if (isEquipped || distance.magnitude > pickupRange) return;
            Transform objectTransform = transform;

            isEquipped = true;
            itemBody.isKinematic = true;
            itemCollider.isTrigger = true;
            weaponContainer.EquipWeapon(weapon.GetId());


            objectTransform.SetParent(gunContainer);
            objectTransform.localPosition = Vector3.zero;
            objectTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        private void Drop()
        {
            isEquipped = false;
            weapon.SetEquiped(false);
            weaponContainer.UnequipWeapon(weapon.GetId());
            
            itemCollider.isTrigger = false;

            transform.SetParent(null);

            itemBody.isKinematic = false;
            itemBody.velocity = playerTransform.GetComponent<Rigidbody>().velocity;
            itemBody.AddForce(playerTransform.transform.forward * dropUpwardForce, ForceMode.Impulse);
            itemBody.AddForce(playerTransform.transform.up * dropUpwardForce, ForceMode.Impulse);
        }
    }
}