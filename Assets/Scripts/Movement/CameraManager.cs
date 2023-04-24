using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraTransform;

    public float mouseSensitivity = 100f;
    public float xRotation = 0f;
    public float yRotation = 0f;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation += mouseX;
        yRotation -= mouseY * mouseSensitivity;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        playerBody.rotation = Quaternion.Euler(0f, xRotation, 0f);
        //cameraTransform.eulerAngles = new Vector3(yRotation, xRotation, 0f);
    }
    
}