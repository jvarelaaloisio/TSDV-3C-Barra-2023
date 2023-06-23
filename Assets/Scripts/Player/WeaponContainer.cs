using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        private IWeapon equipedWeapon;
        private Dictionary<int, IWeapon> idWeapons;

        [SerializeField] private GameObject[] weapons;

        private void Start()
        {
            CreateIdWeapons();
        }

        void CreateIdWeapons()
        {
            idWeapons = new Dictionary<int, IWeapon>(weapons.Length);

            foreach (GameObject weapon in weapons)
            {
                idWeapons.Add(weapon.GetComponent<IWeapon>().Id, weapon.GetComponent<IWeapon>());
            }
        }

        public void EquipWeapon(int id)
        {
            IWeapon weapon = FindWeaponById(id);

            if (weapon == null) return;

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

        public void SwapWeapon()
        {
            IWeapon weapon = GetWeapon();

            int id = 0;

            if (weapon != null)
            {
                id = weapon.Id + 1;
                UnequipWeapon(weapon.Id);
                weapon.GetGameObject().SetActive(false);
            }

            if (id >= weapons.Length) id = 0;

            IWeapon weapon2 = FindWeaponById(id);

            if (!FindWeaponById(id).Inventory)
            {
                foreach (GameObject weaponAux in weapons)
                {
                    if (weaponAux.GetComponent<IWeapon>().Inventory)
                    {
                        weapon2 = weaponAux.GetComponent<IWeapon>();
                    }
                }
            }
            
            weapon2.Equiped = true;
            weapon2.GetGameObject().SetActive(true);
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
                if (weapon.TryGetComponent(out IWeapon weaponComponent) && weaponComponent.Equiped)
                {
                    return weaponComponent;
                }
            }

            return null;
        }

        private IWeapon FindWeaponById(int id)
        {
            return idWeapons[id];
        }
    }
}