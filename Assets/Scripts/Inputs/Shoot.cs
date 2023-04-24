using UnityEngine;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public Transform GunHitbox;

    public ParticleSystem muzzleFlash;

    public void PlayerShoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(GunHitbox.position, GunHitbox.forward, out hit, range))
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