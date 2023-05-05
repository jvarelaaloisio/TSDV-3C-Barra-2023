using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private float range = 100f;
        [SerializeField] private float impactForce = 30f;
        [SerializeField] private float bulletForce = 100f;
        
        [SerializeField] private GameObject bullet;

        [SerializeField] private Transform gunHitbox;

        [SerializeField] private ParticleSystem muzzleFlash;

        public void ShootRaycast()
        {
            muzzleFlash.Play();

            if (Physics.Raycast(gunHitbox.position, gunHitbox.forward, out var hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                if (target != null) target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        public void ShootBullet()
        {
            
        }
    }
}