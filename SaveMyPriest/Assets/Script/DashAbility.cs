using UnityEngine;

public class DashAbility
{
    private readonly Rigidbody2D _rb;
    private readonly float _force;
    private readonly float _duration;
    private readonly float _cooldown;

    private float _durationLeft;
    private float _cooldownLeft;

    public bool IsDashing => _durationLeft > 0f;
    public bool IsOnCooldown => _cooldownLeft > 0f;
    public bool CanDash => !IsDashing && !IsOnCooldown;

    public DashAbility(Rigidbody2D rb, float force = 10f, float duration = 0.15f, float cooldown = 0.0f)
    {
        _rb = rb;
        _force = force;
        _duration = duration;
        _cooldown = cooldown;
    }

    // เริ่ม Dash (ถ้าได้)
    public bool TryDash(Vector2 direction)
    {
        if (!CanDash) return false;

        if (direction == Vector2.zero)
            direction = Vector2.right;

        direction = direction.normalized;

        _durationLeft = _duration;
        _cooldownLeft = _cooldown;

        _rb.AddForce(direction * _force, ForceMode2D.Impulse);
        return true;
    }

    // นับเวลา duration + cooldown
    public void Tick(float dt)
    {
        if (_durationLeft > 0f)
            _durationLeft -= dt;

        if (_cooldownLeft > 0f)
            _cooldownLeft -= dt;
    }
}