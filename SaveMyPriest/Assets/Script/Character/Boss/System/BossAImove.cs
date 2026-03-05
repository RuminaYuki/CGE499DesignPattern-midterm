using UnityEngine;

public class BossAImove
{
    private readonly Rigidbody2D _rb;
    private readonly Transform _origin;
    private readonly Transform _target;
    private readonly float _moveSpeed;

    private Vector2 _moveDir;
    public Vector2 MoveDir => _moveDir;

    public BossAImove(Rigidbody2D rb, Transform origin, Transform target, float moveSpeed)
    {
        _rb = rb;
        _origin = origin;
        _target = target;
        _moveSpeed = moveSpeed;
    }

    public void SetDirection()
    {

        if (GetDirection().sqrMagnitude < 0.0001f)
        {
            _moveDir = Vector2.zero;
            return;
        }

        _moveDir = GetDirection().normalized;
    }

    public float distanceToTarget()
    {
        Vector2 dir = _target.position - _origin.position;
        return dir.magnitude;
    }

    public Vector2 GetDirection()
    {
        Vector2 dir = _target.position - _origin.position;
        return dir;
    }

    public void Stop()
    {
        _rb.linearVelocity = Vector2.zero;
    }

    public void ChaseTick()
    {
        _rb.linearVelocity = _moveDir * _moveSpeed;
    }
}