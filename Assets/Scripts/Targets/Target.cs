using UnityEngine;
using Random = UnityEngine.Random;

namespace Targets
{
    public class Target : MonoBehaviour
    {

        [Header("Targets configuration")] [SerializeField]
        private Movement movement;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float moveDistance = 5f;
        [SerializeField] private float health = 50f;

        [Header("Acceleration options")] [SerializeField]
        private float acceleration = 1f;

        [SerializeField] private float maxSpeed = 10f;

        private float distanceTraveled = 0;
        private float originalSpeed;

        private Vector3 originalPosition;
        private bool direction = true;

        private TargetsManager targetsManager;


        private void Start()
        {
            originalSpeed = speed;
            originalPosition = transform.position;
            targetsManager = FindObjectOfType<TargetsManager>();
        }

        private void Update()
        {
            //(Transform transform, Vector3 originalPos, ref bool direction, float speed,
            //float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed)
            movement.Move(transform, originalPosition, ref direction, speed, moveDistance, distanceTraveled, acceleration, originalSpeed, maxSpeed);
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            targetsManager.UpdateTargets();
            Destroy(gameObject);
        }
        
    }
}