using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private IWeapon equipedWeapon;
        [SerializeField] private IWeapon unequipedWeapon;

        public IWeapon GetWeapon()
        {
            return equipedWeapon;
        }

        /// <summary>
        /// Swaps equiped weapon
        /// </summary>
        public void SwapWeapon()
        {
            if (equipedWeapon == null || unequipedWeapon == null) return;
            
            (equipedWeapon, unequipedWeapon) = (unequipedWeapon, equipedWeapon);
        }
    }
}