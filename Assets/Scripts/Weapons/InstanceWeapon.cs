using Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class InstanceWeapon : Weapon
    {
        [Header("Instance")] [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject gunHitbox;

        [Header("Stats")]
        [SerializeField] private int maxBullets = 30;
        [SerializeField] private float bulletSpeed = 600.0f;
        [SerializeField] private int id = 0;
        [SerializeField] private float bulletDuration = 1;
        
        [Header("Events")] 
        [SerializeField] private SoundEvent onInstanceShotEvent;
        [SerializeField] private SoundEvent onEmptyMagazineEvent;
        [SerializeField] private SoundEvent onReloadEvent;
        private void Awake()
        {
            Id = id;
            MaxBullets = maxBullets;
            Bullets = maxBullets;
            OnReload = onReloadEvent;
            OnEmptyMagazine = onEmptyMagazineEvent;
            OnShot = onInstanceShotEvent;
        }

        /// <summary>
        /// If weapon is equipped, instantiate the bullet prefab forward
        /// </summary>
        public override void Shoot()
        {
            if (!CanShoot()) return;
            BulletShot();
            
            SpawnBullet(out GameObject bullet);
            DestroyBullet(bullet);

        }

        /// <summary>
        /// Instantiates a bullet infront of the gun hitbox going forward.
        /// </summary>
        /// <param name="bullet"> reference to instantiate bullet </param>
        private void SpawnBullet(out GameObject bullet)
        {
            bullet = Instantiate(bulletPrefab, gunHitbox.transform.position, transform.rotation);
            bullet.transform.Rotate(0,0,-90);
            bullet.GetComponent<Rigidbody>()?.AddForce(gunHitbox.transform.forward * bulletSpeed);
        }

        /// <summary>
        /// Destroys bullet after bulletDuration time time 
        /// </summary>
        /// <param name="bullet"> bullet to be destroyed </param>
        private void DestroyBullet(GameObject bullet)
        {
            Destroy(bullet, bulletDuration);
        }

    }
}