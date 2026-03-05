using System;
using UnityEngine;

public class PlayerHeath : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;

    [Header("IFrame")]
    [SerializeField] private float iFrameDuration = 0.5f;

    public HealthSystem HealthSystem { get; private set; }
    public Action OnGetHit;

    private bool isInvincible;
    private float iFrameTimer;

    void Awake()
    {
        HealthSystem = new HealthSystem(maxHealth);
    }

    void Update()
    {
        if (isInvincible)
        {
            iFrameTimer -= Time.deltaTime;

            if (iFrameTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public virtual void TakeDamage(float amount)
    {
        if (isInvincible) return;

        HealthSystem.TakeDamage(amount);
        OnGetHit?.Invoke();

        StartIFrame();
    }

    void StartIFrame()
    {
        isInvincible = true;
        iFrameTimer = iFrameDuration;
    }
}