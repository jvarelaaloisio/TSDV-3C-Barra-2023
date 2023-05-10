using UnityEngine;


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
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        playerBody.rotation = Quaternion.Euler(0f, xRotation, 0f);
        //cameraTransform.eulerAngles = new Vector3(yRotation, xRotation, 0f);
    }
}