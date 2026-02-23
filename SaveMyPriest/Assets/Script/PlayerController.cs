using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    Vector2 input;
    public float speed = 5f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _rb.linearVelocity = input * speed;
    }
}
