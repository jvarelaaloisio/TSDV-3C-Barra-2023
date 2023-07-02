using Audio;
using Targets;
using UnityEngine;

namespace Weapons
{
    public class RaycastWeapon : Weapon
    {
        [Header("Raycast")] 
        [SerializeField] private Transform gunHitbox;
        [SerializeField] private float range = 100f;
        [SerializeField] private LineRenderer lineRenderer;


        [Header("Stats")] 
        [SerializeField] private float damage = 10f;
        [SerializeField] private int maxBullets = 10;
        [SerializeField] private float impactForce = 30f;
        [SerializeField] private int id = 1;
        
        [Header("Events")] 
        [SerializeField] private SoundEvent onRaycastShootEvent;
        [SerializeField] private SoundEvent onEmptyMagazineEvent;
        [SerializeField] private SoundEvent onReloadEvent;

        private void Awake()
        {
            Id = id;
            MaxBullets = maxBullets;
            Bullets = maxBullets;
            OnReload = onReloadEvent;
            OnShot = onRaycastShootEvent;
            OnEmptyMagazine = onEmptyMagazineEvent;
        }

        /// <summary>
        /// Casts a ray going forward
        /// </summary>
        public override void Shoot()
        {
            if(!CanShoot()) return;
            BulletShot();
            
            RaycastHit hit;
            
            if (Physics.Raycast(gunHitbox.position, gunHitbox.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null) target.TakeDamage(damage);
            }
        }

        /// <summary>
        /// Laser beam visual effect.
        /// </summary>
        private void FireLaser()
        {
            
        }

        /// <summary>
        /// Hides laser beam effect.
        /// </summary>
        private void HideLaser()
        {
            lineRenderer.enabled = false;
        }
    }
}