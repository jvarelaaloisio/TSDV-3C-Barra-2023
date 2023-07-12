using UnityEngine;

namespace Player
{
    /// <summary>
    /// Class that enables a character to be moved
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public bool IsSprinting { get; set; }
        
        [SerializeField] private float sprintingSpeed = 4.0f;
        [SerializeField] private float walkingSpeed = 2.0f;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private CharacterController characterController;

        private const float GravityValue = -9.81f;
        
        private Vector3 desiredDirection;
        private Vector3 playerVelocity;

        private void Start()
        {
            if (Camera.main != null) cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            Vector3 currentDirection = GetCharacterDirection();
            characterController.Move(
                currentDirection * (Time.deltaTime * (IsSprinting ? sprintingSpeed : walkingSpeed)));
        }

        /// <summary>
        /// Modifies the direction in which the player is moving relative to camera direction and gravity.
        /// </summary>
        /// <returns> New transform direction </returns>
        private Vector3 GetCharacterDirection()
        {
            Vector3 transformDirection = cameraTransform.TransformDirection(desiredDirection);
            
            transformDirection.y = characterController.isGrounded ? 0 : GravityValue;

            return transformDirection;
        }

        /// <summary>
        /// Recieves the direction the user wants to move in and saves it in desiredDirection.
        /// </summary>
        /// <param name="movement"> direction from the Input </param>
        public void ChangeDirection(Vector2 movement)
        {
            desiredDirection = new Vector3(movement.x, 0, movement.y);
        }
    }
}