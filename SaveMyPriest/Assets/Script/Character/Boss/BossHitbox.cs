using UnityEngine;

public class BossHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && other.CompareTag("Player"))
        {
            damageable.TakeDamage(1f);
        }
    }
}
