using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "movement", menuName = "movements/Horizontal")]
    public class HorizontalMovement : Movement
    {
        public override void Move(Transform transform, Vector3 originalPos, ref bool direction, float speed,
            float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed)
        {
            Vector3 objPosition = transform.position;
            float newPositionX = objPosition.x + (direction ? speed : -speed) * Time.deltaTime;

            if (Mathf.Abs(newPositionX - originalPos.x) > distance)
            {
                direction = !direction;
            }

            transform.position = new Vector3(newPositionX, transform.position.y, objPosition.z);
        }
    }
}
