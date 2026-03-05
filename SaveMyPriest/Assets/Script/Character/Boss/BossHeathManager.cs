using UnityEngine;
using System.Collections;

public class BossHeathManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;
    public HealthSystem HealthSystem { get; private set; }
    private SpriteRenderer _spriteRenderer;
    public Color color;
    public float blinking = 0.25f;
    private Color _defaultColor;
    private Animator animator;

    void Awake()
    {
        HealthSystem = new HealthSystem(maxHealth);
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        _defaultColor = _spriteRenderer.color;
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
        StartCoroutine(TakeDamageAnimation());
        Debug.Log($"{gameObject.name} have {HealthSystem.CurrentHP} HP");
    }
    private void HandleDeath()
    {
        Debug.Log($"{gameObject.name} has died.");
        animator.SetTrigger("DieTrigger");
        animator.SetBool("IsDie",true);
        EventBus.Publish(new BossDefeatedEvent());

    }

    IEnumerator TakeDamageAnimation()
    {
        _spriteRenderer.color = color;
        yield return new WaitForSeconds(blinking);
        
        _spriteRenderer.color = _defaultColor;
    }
}
