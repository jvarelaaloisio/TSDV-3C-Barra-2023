using UnityEngine;

namespace Weapons
{
    public class ShootRaycast : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private Transform gunHitbox;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private float range = 100f;

        [SerializeField] private float damage = 10f;
        [SerializeField] private float impactForce = 30f;
    
        public void Shoot()
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
    }
}
