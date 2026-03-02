using System;
using UnityEngine;

public class PlayerHeath : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;
    public HealthSystem HealthSystem { get; private set; }

    public Action OnGetHit;

    void Awake()
    {
        HealthSystem = new HealthSystem(maxHealth);
    }
    public virtual void TakeDamage(float amount)
    {
        HealthSystem.TakeDamage(amount);
        OnGetHit?.Invoke();
    }
}
