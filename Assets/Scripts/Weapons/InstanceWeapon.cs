using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class InstanceWeapon : MonoBehaviour, IWeapon
    {
        [Header("Instance")] [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject gunHitbox;

        [Header("Stats")] [SerializeField] private int bullets = 30;
        [SerializeField] private int maxBullets = 30;
        [SerializeField] private float bulletSpeed = 600.0f;
        [SerializeField] private int id = 0;

        private void Awake()
        {
            Id = id;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        /// <summary>
        /// If weapon is equiped (active), instanciate the bullet prefab foward
        /// </summary>
        public void Shoot()
        {
            //TODO: Fix - Unclear name
            if (!Equiped) return;

            GameObject bullet = Instantiate(bulletPrefab, gunHitbox.transform.position, gunHitbox.transform.rotation);

            bullet.GetComponent<Rigidbody>()?.AddForce(gunHitbox.transform.forward * bulletSpeed);

            //TODO: TP2 - SOLID
            Destroy(bullet, 1);
        }

        public int Bullets { get; set; }
        public int Id { get; set; }

        public bool Equiped { get; set; }
        public bool Inventory { get; set; }

        public void Reload()
        {
            bullets = maxBullets;
        }
    }
}