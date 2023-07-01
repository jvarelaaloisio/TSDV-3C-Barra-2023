using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "movement", menuName = "movements/Acceleration")]
    public class AccelerationMovement : Movement
    {
        /// <summary>
        /// Moves the object (target) depending on its corresponding behaviour.
        /// </summary>
        /// <param name="transform"> Object's body </param>
        /// <param name="originalPos"> Reference to object's original positon </param>
        /// <param name="direction"> Movement's direction </param>
        /// <param name="speed"> Movement's speed </param>
        /// <param name="distance"> Distance it has to move </param>
        /// <param name="distanceTraveled"> Distance moved </param>
        /// <param name="acceleration"> Acceletarion over time </param>
        /// <param name="ogSpeed"> Original speed </param>
        /// <param name="maxSpeed"> Max speed it can reach </param>
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