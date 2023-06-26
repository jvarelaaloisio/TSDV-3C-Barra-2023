using Targets;
using UnityEngine;

namespace Weapons
{
    public class BulletHit : MonoBehaviour
    {
        [SerializeField] private float damage = 10;

        private static AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            _audioSource.Play();

            if (other.transform.TryGetComponent(out Target target))
            {
                target.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}