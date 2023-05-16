using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform playerBody;
        [SerializeField] private Vector2 rotationSpeed;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Rotate(Vector2 rotation)
        {
            Vector2 scaledDelta = Vector2.Scale(rotation, rotationSpeed) * Time.deltaTime;

            //First person camera rotation
            transform.Rotate(transform.up * scaledDelta.x + transform.right * - scaledDelta.y, Space.Self);
            
            
            //Third person
            //transform.RotateAround(playerBody.position, playerBody.up,scaledDelta.x);
            //transform.RotateAround(playerBody.position, playerBody.right,scaledDelta.y);
            //transform.LookAt(playerBody);
        }
    }
}