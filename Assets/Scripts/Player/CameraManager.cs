using System;
using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform playerBody;
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private float mouseSensitivity = 100f;
        private float xRotation = 0f;
        private float yRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public Transform FindNearestTarget(Vector3 position, float maxDistance)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
            Transform nearestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(position, target.transform.position);

                if (distance < closestDistance && distance <= maxDistance)
                {
                    closestDistance = distance;
                    nearestTarget = target.transform;
                }
            }

            return nearestTarget;
        }

        private void FixedUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation += mouseX;
            yRotation -= mouseY * mouseSensitivity;
            yRotation = Mathf.Clamp(xRotation, Single.MinValue, Single.MaxValue);

            playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);
            //cameraTransform.eulerAngles = new Vector3(yRotation, xRotation, 0f);
        }
    }
}