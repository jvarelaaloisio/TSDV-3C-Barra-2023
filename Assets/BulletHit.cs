using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null) target.TakeDamage(damage);
        }
    }
}