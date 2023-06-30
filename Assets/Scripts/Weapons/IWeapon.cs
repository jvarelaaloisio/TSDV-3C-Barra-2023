using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject GetGameObject()
        {
            return gameObject;
        }
        public abstract void Shoot();
        public virtual int Bullets { get; set; }
        protected int MaxBullets { get; set; }
        public int Id { get; protected set; }
        public void Reload()
        {
            Bullets = MaxBullets;
        }

        public bool Equipped { get; set; }
        public bool Inventory { get; set; }
      
    }
}