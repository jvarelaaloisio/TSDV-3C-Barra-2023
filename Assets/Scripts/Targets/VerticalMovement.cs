using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "movement", menuName = "movements/Vertical")]
    public class VerticalMovement : Movement
    {
        public override void Move(Transform transform, Vector3 originalPos, ref bool direction, float speed,
            float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed)
        {
            Vector3 objPosition = transform.position;

            float newPositionY = objPosition.y + (direction ? speed : -speed) * Time.deltaTime;

            if (Mathf.Abs(newPositionY - originalPos.y) > distance)
            {
                direction = !direction;
            }

            transform.position = new Vector3(transform.position.x, newPositionY, objPosition.z);
        }
    }
}