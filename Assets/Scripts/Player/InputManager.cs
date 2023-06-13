using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        private bool isSprinting = false;
        private static InputManager _instance;

        public static InputManager Instance
        {
            get { return _instance; }
        }

        private PlayerInputs playerInput;

        private void Awake()
        {
            Cursor.visible = false;
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            playerInput = new PlayerInputs();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        public Vector2 GetPlayerMovement()
        {
            return playerInput.World.Move.ReadValue<Vector2>();
        }

        public Vector2 GetMouseDelta()
        {
            return playerInput.World.CameraRotation.ReadValue<Vector2>();
        }

        /// <summary>
        /// Increases movement speed
        /// </summary>
        /// <param name="value"> new speed </param>
        public void OnSprint(InputValue value)
        {
            isSprinting = value.isPressed;
        }

        /// <summary>
        /// In case of having a weapon equiped, shoots
        /// </summary>
        public void OnShoot()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Shoot();
        }

        /// <summary>
        /// Picks up nearest weapon if in range.
        /// </summary>
        public void OnPickUp()
        {
            FindObjectOfType<Pickable>()?.PickAndDrop();
        }

        /// <summary>
        /// Swaps equiped weapon with the unequiped weapon
        /// </summary>
        public void OnSwapWeapon()
        {
            FindObjectOfType<WeaponContainer>().SwapWeapon();
        }
        
        /// <summary>
        /// Resets the bullets count
        /// </summary>
        public void OnReload()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Reload();
        }
    }
}