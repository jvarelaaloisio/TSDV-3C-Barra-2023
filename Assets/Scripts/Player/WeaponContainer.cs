using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponContainer : MonoBehaviour
    {
        private Dictionary<int, Weapon> idWeapons;

        [SerializeField] private GameObject[] weapons;

        private void Start()
        {
            CreateIdWeapons();
        }

        void CreateIdWeapons()
        {
            idWeapons = new Dictionary<int, Weapon>(weapons.Length);

            foreach (GameObject weapon in weapons)
            {
                idWeapons.Add(weapon.GetComponent<Weapon>().Id, weapon.GetComponent<Weapon>());
            }
        }

        public void EquipWeapon(int id)
        {
            Weapon weapon = FindWeaponById(id);

            if (weapon == null) return;

            weapon.Inventory = true;

            bool equipWeapon = true;

            foreach (GameObject weapon2 in weapons)
            {
                if (weapon2.GetComponent<Weapon>().Equipped)
                {
                    equipWeapon = false;
                }
            }

            weapon.GetGameObject().SetActive(equipWeapon);
            weapon.Equipped = equipWeapon;
        }

        public void SwapWeapon()
        {
            Weapon weapon = GetWeapon();

            int id = 0;

            if (weapon != null)
            {
                id = weapon.Id + 1;
                weapon.Equipped = false;
                weapon.GetGameObject().SetActive(false);
            }

            if (id >= weapons.Length) id = 0;

            Weapon weapon2 = FindWeaponById(id);

            if (!FindWeaponById(id).Inventory)
            {
                foreach (GameObject weaponAux in weapons)
                {
                    if (weaponAux.GetComponent<Weapon>().Inventory)
                    {
                        weapon2 = weaponAux.GetComponent<Weapon>();
                    }
                }
            }

            if (!weapon2.Inventory) return;
            
            weapon2.Equipped = true;
            weapon2.GetGameObject().SetActive(true);
        }

        public void UnequipWeapon(int id)
        {
            FindWeaponById(id).Inventory = false;
            FindWeaponById(id).Equipped = false;
        }

        public Weapon GetWeapon()
        {
            foreach (GameObject weapon in weapons)
            {
                if (weapon.TryGetComponent(out Weapon weaponComponent) && weaponComponent.Equipped)
                {
                    return weaponComponent;
                }
            }

            return null;
        }

        private Weapon FindWeaponById(int id)
        {
            return idWeapons[id];
        }
    }
}