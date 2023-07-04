using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public bool IsSprinting { get; private set; }
        private static InputManager _instance;

        public static InputManager Instance => _instance;

        private PlayerInputs playerInput;
        private Pickable[] pickables;
        public static Action OnBulletsUpdate;
        private void Awake()
        {
            Cursor.visible = false;
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            playerInput = new PlayerInputs();
            pickables = FindObjectsOfType<Pickable>();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        /// <summary>
        /// Returns the value of the player's movement input.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPlayerMovement()
        {
            return playerInput.World.Move.ReadValue<Vector2>();
        }

        /// <summary>
        /// Increases movement speed
        /// </summary>
        /// <param name="value"> new speed </param>
        public void OnSprint(InputValue value)
        {
            IsSprinting = value.isPressed;
        }

        /// <summary>
        /// In case of having a weapon equipped, shoots
        /// </summary>
        public void OnShoot()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Shoot();
            OnBulletsUpdate?.Invoke();
        }

        /// <summary>
        /// Picks up nearest weapon if in range.
        /// </summary>
        public void OnPickUp()
        {
            foreach (Pickable pickable in pickables)
            {
                pickable.PickUp();
                OnBulletsUpdate?.Invoke();
            }
        }

        /// <summary>
        /// Drops the currently equipped weapon, if any equipped.
        /// </summary>
        public void OnDrop()
        {
            foreach (Pickable pickable in pickables)
            {
                pickable.Drop();
                OnBulletsUpdate?.Invoke();
            }
        }
        /// <summary>
        /// Swaps equipped weapon with the next available weapon.
        /// </summary>
        public void OnSwapWeapon()
        {
            OnBulletsUpdate?.Invoke();
            FindObjectOfType<WeaponContainer>().SwapWeapon();
        }
        
        /// <summary>
        /// Resets the bullets count
        /// </summary>
        public void OnReload()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Reload();
            OnBulletsUpdate?.Invoke();
        }

        public Vector2 OnCameraRotation()
        {
            return playerInput.World.CameraRotation.ReadValue<Vector2>();
        }
    }
}