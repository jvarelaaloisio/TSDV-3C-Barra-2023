using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private float sensitivityX;
        [SerializeField] private float sensitivityY;

        [SerializeField] private Transform orientation;
        [SerializeField] private InputManager inputManager;
        private float xRotation;
        private float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            MoveCamera();
        }

        /// <summary>
        /// Rotates the camera to follow the mouse.
        /// </summary>
        void MoveCamera()
        {
            Vector2 cameraMovement = inputManager.OnCameraRotation();
            float xMovement = cameraMovement.x  * Time.deltaTime * sensitivityX;
            float yMovement = cameraMovement.y * Time.deltaTime * sensitivityY;

            yRotation += xMovement;
            xRotation -= yMovement;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}