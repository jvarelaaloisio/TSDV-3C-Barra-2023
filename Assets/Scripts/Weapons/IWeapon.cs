using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        GameObject GetGameObject();
        void Shoot();
        int GetBullets();
        bool IsEquiped();
        void SetEquiped(bool equiped);
        void Reload();
    }
}