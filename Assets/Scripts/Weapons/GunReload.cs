using System;
using Player;
using UnityEngine;

namespace Weapons
{
    public class GunReload : MonoBehaviour
    {
        public static Action ReloadSound;
        [SerializeField] private WeaponContainer weaponContainer;
        private void Update()
        {
            if (weaponContainer.GetWeapon().Bullets <= 0)
            {
                ReloadSound?.Invoke();
            }
        }
    }
}