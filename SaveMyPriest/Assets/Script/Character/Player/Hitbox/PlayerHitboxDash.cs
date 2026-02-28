using UnityEngine;

public class PlayerHitboxDash : MonoBehaviour
{
    PlayerContext playerContext;
    void Awake()
    {
        playerContext = GetComponentInParent<PlayerContext>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(playerContext.DashAbility.Damage);
        }
    }
}
