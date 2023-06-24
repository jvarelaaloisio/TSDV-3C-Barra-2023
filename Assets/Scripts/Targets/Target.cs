using UnityEngine;
using Random = UnityEngine.Random;

namespace Targets
{
    public class Target : MonoBehaviour
    {
        //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
        private enum MoveType
        {
            Static,
            Vertical,
            Horizontal,
            Random,
            Acceleration
        }

        [Header("Targets configuration")] 
        [SerializeField] private float speed = 5f;
        [SerializeField] private float moveDistance = 5f;
        [SerializeField] private float health = 50f;
        [SerializeField] private MoveType moveType;

        [Header("Acceleration options")]
        [SerializeField] private float acceleration = 1f;
        [SerializeField] private float maxSpeed = 10f;

        private float distanceTraveled = 0;
        private float originalSpeed;
        private bool isMovingForward = true;

        private Vector3 originalPosition;
        private bool movingRight = true;
        private bool movingUp = true;

        private TargetsManager targetsManager;


        private void Start()
        {
            originalSpeed = speed;
            originalPosition = transform.position;
            targetsManager = FindObjectOfType<TargetsManager>();
        }

        private void Update()
        {
            Move();
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

        private void Move()
        {
            //TODO: TP2 - Strategy
            switch (moveType)
            {
                case MoveType.Horizontal:
                    HorizontalMovement();
                    break;
                case MoveType.Static:
                    break;
                case MoveType.Vertical:
                    VerticalMovement();
                    break;
                case MoveType.Random:
                    RandomMovement();
                    break;
                case MoveType.Acceleration:
                    AccelerationMovement();
                    break;
            }
        }

        //TODO: Fix - Unclear name
        private void HorizontalMovement()
        {
            Vector3 objPosition = transform.position;
            float newPositionX = objPosition.x + (movingRight ? speed : -speed) * Time.deltaTime;

            if (Mathf.Abs(newPositionX - originalPosition.x) > moveDistance)
            {
                movingRight = !movingRight;
            }

            transform.position = new Vector3(newPositionX, transform.position.y, objPosition.z);
        }

        private void VerticalMovement()
        {
            Vector3 objPosition = transform.position;

            float newPositionY = objPosition.y + (movingUp ? speed : -speed) * Time.deltaTime;

            if (Mathf.Abs(newPositionY - originalPosition.y) > moveDistance)
            {
                movingUp = !movingUp;
            }

            transform.position = new Vector3(transform.position.x, newPositionY, objPosition.z);
        }

        private void RandomMovement()
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized * moveDistance;

            Vector3 targetPosition = originalPosition + randomDirection;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 5);
        }

        private void AccelerationMovement()
        {
            Vector3 movementDirection = isMovingForward ? Vector3.forward : Vector3.back;

            transform.Translate(movementDirection * (speed * Time.deltaTime));

            distanceTraveled += speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, originalSpeed, maxSpeed);

            if (distanceTraveled >= moveDistance)
            {
                isMovingForward = !isMovingForward;
                distanceTraveled = 0f;
            }
        }
    }
}