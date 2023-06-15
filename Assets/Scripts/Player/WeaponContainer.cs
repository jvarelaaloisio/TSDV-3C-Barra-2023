using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        private IWeapon equipedWeapon;
        private IWeapon unequipedWeapon;

        public IWeapon GetWeapon()
        {
            return equipedWeapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            if (equipedWeapon == null)
            {
                equipedWeapon = weapon;
            }
            else if (unequipedWeapon == null)
            {
                unequipedWeapon = weapon;
            }
        }

        public void SetEquipedWeapon(IWeapon weapon)
        {
            equipedWeapon = weapon;
        }

        public void SetUnequipedWeapon(IWeapon weapon)
        {
            unequipedWeapon = weapon;
        }

        /// <summary>
        /// Swaps equiped weapon
        /// </summary>
        public void SwapWeapon()
        {
            (equipedWeapon, unequipedWeapon) = (unequipedWeapon, equipedWeapon);
        }
    }
}