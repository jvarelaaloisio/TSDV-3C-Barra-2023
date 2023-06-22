using UnityEngine;

namespace Player
{
    public class CameraPosition : MonoBehaviour
    {
        [SerializeField] private Transform cameraPosition;

        private void LateUpdate()
        {
            cameraPosition.position = transform.position;
        }
    }
}
