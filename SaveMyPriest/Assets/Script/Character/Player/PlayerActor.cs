using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    private Movement _movement;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _dashForce = 10f;
    [SerializeField] private int AttackDamage = 10;
    void Awake()
    {        
        _rb = GetComponent<Rigidbody2D>();
        _movement = new Movement(_rb, _speed);
    }
    public void Move(Vector2 direction)
    {
        _movement.Move(direction);
    }
    public void Dash(Vector2 direction)
    {
        _rb.AddForce(direction * _dashForce, ForceMode2D.Impulse);
    }
    public void Attack()
    {
        Debug.Log("Player Attacks with " + AttackDamage + " damage!");
    }
}
