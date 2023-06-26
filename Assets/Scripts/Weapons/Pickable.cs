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
        [SerializeField] private float forwardForce = 5;
        [SerializeField] private float upwardForce = 5;

        private Vector3 distance;

        private void Start()
        {
            weapon = GetComponent<IWeapon>();
            itemBody = GetComponent<Rigidbody>();
            itemCollider = GetComponent<BoxCollider>();

            if (!weapon.Equipped)
            {
                weapon.Equipped = false;
                itemBody.isKinematic = false;
                itemCollider.isTrigger = false;
            }
        }


        public void PickUp()
        {
            distance = playerTransform.position - transform.position;

            if (weapon.Equipped || distance.magnitude > pickupRange) return;

            itemBody.isKinematic = true;
            itemCollider.isTrigger = true;
            weaponContainer.EquipWeapon(weapon.Id);


            Transform objectTransform = transform;
            objectTransform.SetParent(gunContainer);
            objectTransform.localPosition = Vector3.zero;
            objectTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        public void Drop()
        {
            if (!weapon.Equipped) return;

            weapon.Equipped = false;
            weaponContainer.UnequipWeapon(weapon.Id);

            itemCollider.isTrigger = false;

            transform.SetParent(null);

            itemBody.isKinematic = false;
            itemBody.velocity = playerTransform.GetComponent<Rigidbody>().velocity;
            itemBody.AddForce(playerTransform.transform.forward * forwardForce, ForceMode.Impulse);
            itemBody.AddForce(playerTransform.transform.up * upwardForce, ForceMode.Impulse);
        }
    }
}