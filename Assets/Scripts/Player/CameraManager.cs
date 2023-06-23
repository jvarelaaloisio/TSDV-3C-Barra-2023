using System;
using UnityEngine;

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

        void MoveCamera()
        {
            //TODO: Fix - Old inputManager
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            
        }
    }
}