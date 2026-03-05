using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossContext : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform _chasePoint;
    [SerializeField] private Transform _target;

    [Header("Move")]
    [SerializeField] private float _moveSpeed = 3f;

    [Header("Distances")]
    [SerializeField] private float _stopDistance = 1.5f;

    [Header("Charge (reuse DashAbility)")]
    [SerializeField] private float _chargeForce = 10f;
    [SerializeField] private float _chargeDuration = 0.15f;

    


    public Transform ChasePoint => _chasePoint;
    public Transform Target => _target;
    public BossAImove Chase { get; private set; }
    public CharacterFlipper Flipper { get; private set; }
    public DashAbility ChargeAttack{ get; private set; }
    public Rigidbody2D Rb {get; private set;}
    public ShooterFinal Shooter { get; private set; }
    

    public float StopDistance => _stopDistance;

    private int _numberOfPattern;
    public int numberofPattern => _numberOfPattern;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();

        if (_chasePoint == null)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) _chasePoint = p.transform;
        }

        Shooter = GetComponent<ShooterFinal>();
        Chase = new BossAImove(Rb, transform, _chasePoint, _moveSpeed);
        Flipper = new CharacterFlipper(transform);
        ChargeAttack = new DashAbility(Rb,_chargeForce, 1,_chargeDuration, 0f);
    }

    private void Update()
    {
        ChargeAttack.Tick(Time.deltaTime);
    }

    public Vector2 DirectionToPlayer()
    {
        Vector2 dir = _target.position - transform.position;
        return dir.normalized;
    }
    

    private void OnDrawGizmosSelected()
    {
    // วงระยะหยุด
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _stopDistance);
    }

    public void NumberOfRandomPattern(int numberOfPattern)
    {
        _numberOfPattern = numberOfPattern;
    }
}
