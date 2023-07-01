using Audio;
using Targets;
using UnityEngine;

namespace Weapons
{
    public class RaycastWeapon : Weapon
    {
        [Header("Raycast")] [SerializeField] private Transform gunHitbox;
        [SerializeField] private float range = 100f;
        [SerializeField] private LineRenderer lineRenderer;


        [Header("Stats")] [SerializeField] private float damage = 10f;
        [SerializeField] private int maxBullets = 10;
        [SerializeField] private float impactForce = 30f;
        [SerializeField] private int id = 1;

        [Header("Events")] [SerializeField] private SoundEvent onRaycastShoot;
        [SerializeField] private SoundEvent onEmptyMagazine;
        [SerializeField] private SoundEvent OnReload;

        private void Awake()
        {
            Id = id;
            MaxBullets = maxBullets;
            Bullets = maxBullets;
        }

        public override void Shoot()
        {
            if (!Equipped) return;
            if (Bullets <= 0)
            {
                onEmptyMagazine.Raise();
                return;
            }

            Bullets--;
            onRaycastShoot.Raise();
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

        public override void Reload()
        {
            Bullets = MaxBullets;
            OnReload.Raise();
        }

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

        private void HideLaser()
        {
            lineRenderer.enabled = false;
        }
    }
}