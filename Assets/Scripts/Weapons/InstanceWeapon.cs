using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class InstanceWeapon : MonoBehaviour, IWeapon
    {
        [Header("Instance")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject gunHitbox;

        [Header("Stats")] 
        [SerializeField] private int bullets = 30;
        [SerializeField] private int maxBullets = 30;
        [SerializeField] private float bulletSpeed = 600.0f;
        [SerializeField] private int id = 0;
        private bool inInventory = false;

        private bool isActive;

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        /// <summary>
        /// If weapon is equiped (active), instanciate the bullet prefab foward
        /// </summary>
        public void Shoot()
        {
            if (!isActive) return;

            GameObject bullet = Instantiate(bulletPrefab, gunHitbox.transform.position, gunHitbox.transform.rotation);

            bullet.GetComponent<Rigidbody>()?.AddForce(gunHitbox.transform.forward * bulletSpeed);

            Destroy(bullet, 1);
        }

        public int GetBullets()
        {
            return bullets;
        }

        public bool IsEquiped()
        {
            return isActive;
        }

        public void SetEquiped(bool equiped)
        {
            isActive = equiped;
        }

        public void Reload()
        {
            bullets = maxBullets;
        }

        public int GetId()
        {
            return id;
        }

        public bool InInventory()
        {
            return inInventory;
        }

        public void SetInventory(bool inInventory)
        {
             this.inInventory = inInventory;

        }
    }
}