using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<IWeapon> weapons;

        public IWeapon GetWeapon()
        {
            return weapons[0];
        }

        public void SetWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        /// <summary>
        /// Swaps equiped weapon
        /// </summary>
        public void SwapWeapon()
        {
            if (weapons[1] == null) return;
            
            (weapons[0], weapons[1]) = (weapons[1], weapons[0]);
        }
    }
}