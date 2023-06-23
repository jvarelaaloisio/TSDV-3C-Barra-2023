using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        GameObject GetGameObject();
        void Shoot();
        int Bullets { get; set; }
        int Id { get; set; }
        void Reload();

        bool Equiped { get; set; }
        bool Inventory { get; set; }
      
    }
}