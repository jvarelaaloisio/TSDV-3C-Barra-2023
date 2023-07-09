using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        #region Events

        public static Action OnShootEvent;
        public static Action OnReloadEvent;
        public static Action OnPickUpEvent;
        public static Action OnDropEvent;
        public static Action OnSwapWeaponEvent;

        #endregion

        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private PlayerController playerController;

        private bool isSprinting;
        private Pickable[] pickables;

        private void Awake()
        {
            Cursor.visible = false;

            pickables = FindObjectsOfType<Pickable>();
        }

        /// <summary>
        /// Player movement logic.
        /// </summary>
        public void OnMove(InputValue context)
        {
            Vector2 movementInput = context.Get<Vector2>();
            playerController.Move(movementInput, isSprinting);
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
        /// In case of having a weapon equipped, shoots.
        /// </summary>
        public void OnShoot()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Shoot();
            OnShootEvent?.Invoke();
        }

        /// <summary>
        /// Picks up nearest weapon if in range.
        /// </summary>
        public void OnPickUp()
        {
            foreach (Pickable pickable in pickables)
            {
                pickable.PickUp();
                OnPickUpEvent?.Invoke();
            }
        }

        /// <summary>
        /// Drops the currently equipped weapon, if any.
        /// </summary>
        public void OnDrop()
        {
            foreach (Pickable pickable in pickables)
            {
                pickable.Drop();
                OnDropEvent?.Invoke();
            }
        }

        /// <summary>
        /// Swaps equipped weapon with the next available weapon.
        /// </summary>
        public void OnSwapWeapon()
        {
            OnSwapWeaponEvent?.Invoke();
            FindObjectOfType<WeaponContainer>().SwapWeapon();
        }

        /// <summary>
        /// Resets the bullets count.
        /// </summary>
        public void OnReload()
        {
            FindObjectOfType<WeaponContainer>().GetWeapon()?.Reload();
            OnReloadEvent?.Invoke();
        }

        /// <summary>
        /// Rotates the camera with the mouse or controller's input
        /// </summary>
        public void OnCameraRotation(InputValue context)
        {
            Vector2 cameraMovement = context.Get<Vector2>();
            cameraManager.MoveCamera(cameraMovement);
        }
    }
}