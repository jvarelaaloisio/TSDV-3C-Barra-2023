using UnityEngine;

namespace Targets
{
    public abstract class Movement : ScriptableObject
    {
        public abstract void Move(Transform transform, Vector3 originalPos, ref bool direction, float speed, float distance, float distanceTraveled, float acceleration, float ogSpeed, float maxSpeed);
    }
}