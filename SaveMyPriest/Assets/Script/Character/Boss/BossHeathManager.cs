using UnityEngine;

public class BossHeathManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;
    public HealthSystem HealthSystem { get; private set; }

    void Awake()
    {
        HealthSystem = new HealthSystem(maxHealth);
    }
    void OnEnable()
    {
        HealthSystem.OnDied += HandleDeath;
    }
    void OnDisable()
    {
        HealthSystem.OnDied -= HandleDeath;
    }
    public virtual void TakeDamage(float amount)
    {
        HealthSystem.TakeDamage(amount);
    }
    private void HandleDeath()
    {
        Debug.Log($"{gameObject.name} has died.");
        gameObject.SetActive(false);
    }
}
