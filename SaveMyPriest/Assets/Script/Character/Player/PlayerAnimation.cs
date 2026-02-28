using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _animator;

    private PlayerActor _playerActor;
    
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();

        _playerActor = GetComponentInParent<PlayerActor>();

    }
    private void OnEnable()
    {
        _playerActor.OnDash += Dash;
    }

    private void OnDisable()
    {
        _playerActor.OnDash -= Dash;
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
}
