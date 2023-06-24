using Targets;
using UnityEngine;

namespace Weapons
{
    public class BulletHit : MonoBehaviour
    {
        [SerializeField] private float damage = 10;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Target target))
            {
                target.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

    }
}