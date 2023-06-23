using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        //TODO: TP2 - Remove unused methods/variables/classes
        private IWeapon equipedWeapon;
        private Dictionary<int, IWeapon> idWeapon;

        [SerializeField] private GameObject[] weapons;

        private void Start()
        {
            idWeapon = new Dictionary<int, IWeapon>(weapons.Length);
            foreach (GameObject weapon in weapons)
            {
                idWeapon.Add(weapon.GetComponent<IWeapon>().Id, weapon.GetComponent<IWeapon>());
            }
        }

        public void EquipWeapon(int id)
        {
            IWeapon weapon = FindWeaponById(id);
            if (weapon != null)
            {
                weapon.Inventory = true;

                bool equipWeapon = true;

                foreach (GameObject weapon2 in weapons)
                {
                    if (weapon2.GetComponent<IWeapon>().Equiped)
                    {
                        equipWeapon = false;
                    }
                }

                weapon.GetGameObject().SetActive(equipWeapon);
                weapon.Equiped = equipWeapon;
            }
        }

        public void SwapWeapon()
        {
            IWeapon weapon = GetWeapon();

            if(weapon == null) return;
            
            weapon.Equiped = false;
            weapon.GetGameObject().SetActive(false);
            //TODO: Fix - Too many iterations
            foreach (GameObject weapon2 in weapons)
            {
                if (weapon2.GetComponent<IWeapon>().Id != weapon.Id &&
                    weapon2.GetComponent<IWeapon>().Inventory)
                {
                    weapon2.GetComponent<IWeapon>().Equiped = true;
                    weapon2.SetActive(true);
                    break;
                }
            }
        }

        public void UnequipWeapon(int id)
        {
            FindWeaponById(id).Inventory = false;
            FindWeaponById(id).Equiped = false;
        }

        public IWeapon GetWeapon()
        {
            foreach (GameObject weapon in weapons)
            {
                IWeapon weaponComponent;
                if (weapon.TryGetComponent(out weaponComponent) && weaponComponent.Equiped)
                {
                    return weaponComponent;
                }
            }

            return null;
        }

        //TODO: Fix - This could be cached in a dictionary
        private IWeapon FindWeaponById(int id)
        {
            return idWeapon[id];
        }
    }
}