using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float rotationSpeedX = 1f;
    [SerializeField] private float rotationSpeedY = 1f;
    [SerializeField] private float maxRotationSpeed = 5f;
    [SerializeField] private float maxRotationAngle = 90f;
    public Transform characterTransform;

    private Vector2 rotationInput;
    private InputAction rotateAction;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rotateAction = new InputAction(binding: "<Mouse>/delta");
        rotateAction.performed += OnRotate;
    }

    private void OnEnable()
    {
        rotateAction.Enable();
    }

    private void OnDisable()
    {
        rotateAction.Disable();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Limit the rotation speed
        float clampedRotationSpeed = Mathf.Clamp(rotationInput.y, 0f, maxRotationSpeed);

        float rotationX = clampedRotationSpeed * Time.deltaTime;
        float rotationY = rotationInput.x * rotationSpeedY * Time.deltaTime;

        // Apply rotation on the Y-axis (horizontal rotation)
        transform.Rotate(Vector3.up, rotationY);

        // Apply rotation on the X-axis (vertical rotation)
        float newRotationAngle = transform.eulerAngles.x - rotationX;
        float clampedRotationAngle = Mathf.Clamp(newRotationAngle, -maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(clampedRotationAngle, transform.eulerAngles.y, 0f);

        // Rotate the character towards the camera's direction
        if (characterTransform != null)
        {
            characterTransform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        }
    }
}