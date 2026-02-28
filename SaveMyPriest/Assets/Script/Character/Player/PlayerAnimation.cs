using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _animator;

    private PlayerContext _playerContext;
    private PlayerHeathManager _playerHeathManager;
    
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();

        _playerContext = GetComponentInParent<PlayerContext>();
        _playerHeathManager = GetComponentInParent<PlayerHeathManager>();

    }
    private void OnEnable()
    {
        _playerContext.OnDash += Dash;
        _playerContext.OnAttack += Attack;
        _playerHeathManager.OnGetHit += Hurt;
        _playerHeathManager.HealthSystem.OnDied += Die;
    }

    private void OnDisable()
    {
        _playerContext.OnDash -= Dash;
        _playerContext.OnAttack -= Attack;
        _playerHeathManager.OnGetHit -= Hurt;
        _playerHeathManager.HealthSystem.OnDied -= Die;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        float walkSpeed = new Vector2(_rb.linearVelocity.x,_rb.linearVelocity.y).magnitude;
        _animator.SetFloat("Velocity", walkSpeed);
    }

    void Dash()
    {
        _animator.SetTrigger("DashTrigger");
    }

    void Attack()
    {
        _animator.SetTrigger("AttackTrigger");
    }
    void Hurt()
    {
        _animator.SetTrigger("HurtTrigger");
    }
    void Die()
    {
        _animator.SetTrigger("DieTrigger");
    }
}
