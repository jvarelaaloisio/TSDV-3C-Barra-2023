using System;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        //TODO: TP2 - Remove unused methods/variables/classes
        private IWeapon equipedWeapon;

        [SerializeField] private GameObject[] weapons;

        public void EquipWeapon(int id)
        {
            if (FindWeaponById(id) != null)
            {
                IWeapon weapon = FindWeaponById(id);
                weapon.SetInventory(true);

                bool equipWeapon = true;

                foreach (GameObject weapon2 in weapons)
                {
                    if (weapon2.GetComponent<IWeapon>().IsEquiped())
                    {
                        equipWeapon = false;
                    }
                }

                weapon.SetEquiped(equipWeapon);
            }
        }

        public void SwapWeapon()
        {
            foreach (GameObject weapon in weapons)
            {
                if (weapon.GetComponent<IWeapon>().IsEquiped())
                {
                    weapon.GetComponent<IWeapon>().SetEquiped(false);
                    //TODO: Fix - Too many iterations
                    foreach (GameObject weapon2 in weapons)
                    {
                        if (weapon2.GetComponent<IWeapon>().GetId() != weapon.GetComponent<IWeapon>().GetId() &&
                            weapon2.GetComponent<IWeapon>().InInventory())
                        {
                            weapon2.GetComponent<IWeapon>().SetEquiped(true);
                            break;
                        }
                    }
                }
            }
        }

        public void UnequipWeapon(int id)
        {
            FindWeaponById(id).SetInventory(false);
            FindWeaponById(id).SetEquiped(false);
        }

        public IWeapon GetWeapon()
        {
            foreach (GameObject weapon in weapons)
            {
                //TODO: Fix - Cache value
                if (weapon.GetComponent<IWeapon>().IsEquiped())
                {
                    return weapon.GetComponent<IWeapon>();
                }
            }

            return null;
        }

        //TODO: Fix - This could be cached in a dictionary
        private IWeapon FindWeaponById(int id)
        {
            foreach (GameObject weapon in weapons)
            {
                if (weapon.GetComponent<IWeapon>().GetId() == id)
                {
                    return weapon.GetComponent<IWeapon>();
                }
            }

            return null;
        }
    }
}