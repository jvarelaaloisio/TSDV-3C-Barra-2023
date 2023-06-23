using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        //TODO: TP2 - Remove unused methods/variables/classes
        GameObject GetGameObject();
        void Shoot();
        int GetBullets();
        bool IsEquiped();
        void SetEquiped(bool equiped);
        void Reload();

        int GetId();
        bool InInventory();
        void SetInventory(bool inInventory);

    }
}