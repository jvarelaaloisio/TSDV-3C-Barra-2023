using UnityEngine;

namespace Weapons
{
    public class RaycastWeapon : MonoBehaviour, IWeapon
    {
        [Header("Raycast")] [SerializeField] private Transform gunHitbox;
        [SerializeField] private float range = 100f;
        [SerializeField] private LineRenderer lineRenderer;


        [Header("Stats")] [SerializeField] private float damage = 10f;
        [SerializeField] private int bullets = 10;
        [SerializeField] private int maxBullets = 10;
        [SerializeField] private float impactForce = 30f;
        [SerializeField] private int id = 1;
        private bool inInventory = false;

        private bool isActive;


        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Shoot()
        {
            if (!isActive) return;

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

        public int GetId()
        {
            return id;
        }

        public bool InInventory()
        {
            return inInventory;
        }

        public void SetInventory(bool inInventory)
        {
            this.inInventory = inInventory;
        }

        private void FireLaser()
        {
            lineRenderer.enabled = true;

            RaycastHit hit;
            Vector3 position = transform.position;
            if (Physics.Raycast(position, transform.forward, out hit, range))
            {
                lineRenderer.SetPosition(0, position);
                lineRenderer.SetPosition(1, hit.point);

                // Perform actions when the laser hits an object (e.g., apply damage, trigger effects)
                if (hit.collider != null)
                {
                    // Object hit! Access hit.collider.gameObject for further actions.
                }
            }
            else
            {
                lineRenderer.SetPosition(0, position);
                lineRenderer.SetPosition(1, position + transform.forward * range);
            }

            // Hide the laser beam after a short delay (adjust as needed)
            Invoke(nameof(HideLaser), 0.1f);
        }

        private void HideLaser()
        {
            lineRenderer.enabled = false;
        }
    }
}