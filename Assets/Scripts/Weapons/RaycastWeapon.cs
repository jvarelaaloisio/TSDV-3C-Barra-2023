﻿using UnityEngine;

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

        //TODO: Fix - Should be native Setter/Getter
        public int GetBullets()
        {
            return bullets;
        }

        //TODO: Fix - Should be native Setter/Getter
        public bool IsEquiped()
        {
            return isActive;
        }

        //TODO: Fix - Should be native Setter/Getter
        public void SetEquiped(bool equiped)
        {
            isActive = equiped;
        }

        //TODO: Fix - Repeated code
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
            //TODO: TP2 - SOLID
            lineRenderer.enabled = true;

            //TODO: Fix - Calculating hit twice
            RaycastHit hit;
            Vector3 position = transform.position;
            if (Physics.Raycast(position, transform.forward, out hit, range))
            {
                lineRenderer.SetPosition(0, position);
                lineRenderer.SetPosition(1, hit.point);

                //TODO: TP2 - Remove unused methods/variables/classes
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

            //TODO: Fix - Hardcoded value
            //TODO: Fix - These comments really make it feel as if this is not your code.
            // Hide the laser beam after a short delay (adjust as needed)
            Invoke(nameof(HideLaser), 0.1f);
        }

        private void HideLaser()
        {
            lineRenderer.enabled = false;
        }
    }
}