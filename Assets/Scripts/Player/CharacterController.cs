using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    /// <summary>
    /// Class that enables a character to be moved
    /// </summary>
    public class CharacterController : MonoBehaviour
    {

        [Header("Setup")] [SerializeField] private Rigidbody rigidBody;

        [SerializeField] private Transform feetPivot;

        [Header("Movement")] [SerializeField] private float movementSpeed = 10f;

        [SerializeField] private float minJumpDistance = 0.25f;

        private Vector3 currentMovement;
        private Coroutine jumpCoroutine;

        private bool isSprinting = false;

        private bool isJumpInput;
        [SerializeField] private float coyoteTime;

        private void OnValidate()
        {
            rigidBody ??= GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (!rigidBody)
            {
                //<color=xxx> nos permite colorear una string
                //mas data sobre las string con $ (string interpolation):
                //https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/tokens/interpolated
                Debug.LogError($"<color=grey>{name}:</color> {nameof(rigidBody)} is null!" +
                               $"\n<color=red>Disabling this component to avoid NullReferences!</color>");
                enabled = false;
            }

            if (!feetPivot)
            {
                Debug.LogWarning($"<color=grey>{name}:</color> {nameof(feetPivot)} is null!");
            }
        }

        private void FixedUpdate()
        {
            float playerSpeed = isSprinting ? movementSpeed * 2 : movementSpeed;

            rigidBody.velocity = currentMovement * playerSpeed + Vector3.up * rigidBody.velocity.y;
        }

        /// <summary>
        /// moves the character by walking
        /// </summary>
        public void OnMove(InputValue context)
        {
            var movementInput = context.Get<Vector2>();
            AnimationState animationState = FindObjectOfType<AnimationState>();
            currentMovement = new Vector3(movementInput.x, 0, movementInput.y);

            Quaternion meshRotation = rigidBody.transform.rotation;
            currentMovement = meshRotation * currentMovement;
            
            if (movementInput.x != 0 || movementInput.y != 0)
            {
                animationState.PlayerWalking();
            }
            else
            {
                animationState.PlayerIdle();
            }
        }

        public void OnSprint(InputValue value)
        {
            isSprinting = value.isPressed;
        }
        public void OnShoot()
        {
            FindObjectOfType<ShootRaycast>()?.Shoot();
        }

        public void OnShootSecondary()
        {
            FindObjectOfType<ShootInstance>()?.Fire();
        }

        public void OnPickUp()
        {
            Debug.Log("Pick up");
            FindObjectOfType<Pickable>()?.PickUp();
        }

        public void OnLockTarget()
        {
            Debug.Log("LockTarget");
            Transform nearestTarget = GetComponent<CameraManager>().FindNearestTarget(transform.position, 20f);

            if (nearestTarget != null)
            {
                rigidBody.transform.LookAt(nearestTarget);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (!feetPivot)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(feetPivot.position, feetPivot.position + Vector3.down * minJumpDistance);
        }
    }
}