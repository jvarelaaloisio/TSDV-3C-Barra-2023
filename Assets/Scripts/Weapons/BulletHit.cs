using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    private void OnCollisionEnter(Collision other)
    {
        Target target = other.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log(target.transform.name);
        }
    }
}