using UnityEngine;

public class AttackAbility
{
    private readonly float _duration;
    private readonly float _cooldown;
    private readonly int _damage;

    private float _durationLeft;
    private float _cooldownLeft;

    public bool IsAttacking => _durationLeft > 0f;
    public bool IsOnCooldown => _cooldownLeft > 0f;
    public bool CanAttack => !IsAttacking && !IsOnCooldown;

    public AttackAbility(int damage = 10, float duration = 0.25f, float cooldown = 0.0f)
    {
        _damage = damage;
        _duration = duration;
        _cooldown = cooldown;
    }

    public bool TryAttack()
    {
        if (!CanAttack) return false;

        _durationLeft = _duration;
        _cooldownLeft = _cooldown;

        return true;
    }

    public void Tick(float dt)
    {
        if (_durationLeft > 0f)
            _durationLeft -= dt;

        if (_cooldownLeft > 0f)
            _cooldownLeft -= dt;
    }
}