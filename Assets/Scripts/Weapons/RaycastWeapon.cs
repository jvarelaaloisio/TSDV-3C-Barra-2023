using Audio;
using Targets;
using UnityEngine;
using UnityEngine.Serialization;

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
            
            FireLaser();
            if (Physics.Raycast(gunHitbox.position, gunHitbox.forward, out var hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();

                if (target != null) target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        /// <summary>
        /// Laser beam visual effect.
        /// </summary>
        private void FireLaser()
        {
            //TODO: TP2 - SOLID
            lineRenderer.enabled = true;

            //TODO: Fix - Calculating hit twice
            Vector3 startPoint = gunHitbox.position;
            Vector3 endPoint = transform.position + transform.forward * range;

            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
            Invoke(nameof(HideLaser), 0.1f);
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