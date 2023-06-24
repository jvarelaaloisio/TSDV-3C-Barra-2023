using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "movement", menuName = "movements/Acceleration")]
    public class AccelerationMovement : Movement
    {
        public override void Move(Transform transform, Vector3 originalPos, ref bool direction, float speed,
            float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed)
        {
            Vector3 movementDirection = direction ? Vector3.forward : Vector3.back;

            transform.Translate(movementDirection * (speed * Time.deltaTime));

            distanceTraveled += speed * Time.deltaTime;
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, ogSpeed, maxSpeed);

            if (distanceTraveled >= distance)
            {
                direction = !direction;
                distanceTraveled = 0f;
            }
        }
    }
}