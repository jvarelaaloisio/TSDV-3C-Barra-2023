using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        GameObject GetGameObject();
        void Shoot();
        int GetBullets();
        bool IsEquipped();
        void SetEquipped(bool equipped);
        void Reload();
    }
}