using UnityEngine;

public class Movement
{
    private Rigidbody2D _rb;
    private float _speed;

    public Movement(Rigidbody2D rb, float speed)
    {
        _rb = rb;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = direction * _speed;
    }
}
