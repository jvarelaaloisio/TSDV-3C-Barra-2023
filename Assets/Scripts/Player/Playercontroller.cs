using UnityEngine;

namespace Player
{
    /// <summary>
    /// Class that enables a character to be moved
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class Playercontroller : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private float rotationSensitivity = 5f;

        private float originalSpeed;
        private Vector3 playerVelocity;
        private CharacterController controller;
        private InputManager inputManager;
        private Transform cameraTransform;
        private bool groundedPlayer;


        private void Start()
        {
            if (Camera.main != null) cameraTransform = Camera.main.transform;
            controller = FindObjectOfType<CharacterController>();
            inputManager = InputManager.Instance;
            originalSpeed = playerSpeed;
        }

        private void Update()
        {
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Move();
        }

        /// <summary>
        /// Character movement
        /// </summary>
        //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
        private void Move()
        {
            Vector2 movement = inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0;

            // Rotate the character towards the move direction
            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    rotationSensitivity * Time.deltaTime);
            }

            playerSpeed = inputManager.IsSprinting ? originalSpeed * 2f : originalSpeed;
            controller.Move(move * (Time.deltaTime * playerSpeed));

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}