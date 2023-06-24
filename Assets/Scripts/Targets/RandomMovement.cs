using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "movement", menuName = "movements/Random")]
    public class RandomMovement : Movement
    {
        public override void Move(Transform transform, Vector3 originalPos, ref bool direction, float speed,
            float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized * distance;

            Vector3 targetPosition = originalPos + randomDirection;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 5);
        }
    }
}