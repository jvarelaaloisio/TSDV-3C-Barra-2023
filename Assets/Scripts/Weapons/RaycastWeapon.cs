using UnityEngine;

namespace Weapons
{
    public class RaycastWeapon : MonoBehaviour, IWeapon
    {
        [Header("Raycast")] [SerializeField] private Transform gunHitbox;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private float range = 100f;


        [Header("Stats")] [SerializeField] private float damage = 10f;
        [SerializeField] private int bullets = 10;
        [SerializeField] private int maxBullets = 10;
        [SerializeField] private float impactForce = 30f;
        private bool isActive;


        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Shoot()
        {
            muzzleFlash.Play();

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
    }
}