using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class Shoot : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private Transform gunHitbox;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private float range = 100f;

        [SerializeField] private float damage = 10f;
        [SerializeField] private float impactForce = 30f;



        [Header("Instance")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletPoint;
        [SerializeField] private float bulletSpeed = 600.0f;


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

        
        public void Fire()
        {
            Debug.Log("Fire");

            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(bulletPoint.transform.forward * bulletSpeed);

            Destroy(bullet, 1);
        }
   }
}