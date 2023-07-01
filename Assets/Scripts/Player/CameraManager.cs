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
            float mouseX = Mouse.current.delta.x.ReadValue() * Time.deltaTime * sensitivityX;
            float mouseY = Mouse.current.delta.y.ReadValue() * Time.deltaTime * sensitivityY;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}