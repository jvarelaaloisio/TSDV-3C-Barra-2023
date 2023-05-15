using UnityEngine;

namespace Weapons
{
    public class ShootInstance : MonoBehaviour
    {
        [Header("Instance")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject gunHitbox;
        [SerializeField] private float bulletSpeed = 600.0f;
        public bool isActive;
        public void Fire()
        {
            if(!isActive) return;
            Debug.Log("Fire");
            GameObject bullet = Instantiate(bulletPrefab, gunHitbox.transform.position, gunHitbox.transform.rotation);

            bullet.GetComponent<Rigidbody>()?.AddForce(gunHitbox.transform.forward * bulletSpeed);

            Destroy(bullet, 1);
        }
    }
}