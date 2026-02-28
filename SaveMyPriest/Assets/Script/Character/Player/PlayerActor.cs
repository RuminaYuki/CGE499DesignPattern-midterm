using System;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerActor : MonoBehaviour
{

    private Movement _movement;
    private DashAbility _dashAbility;
    private AttackAbility _attackAbility;
    private Rigidbody2D _rb;

    [Header("Walk")]
    [SerializeField] private float _speed = 5f;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 10f;
    [SerializeField] private float _dashduration = 0.15f;
    [SerializeField] private float _dashcooldown = 0.5f;

    [Header("Attack")]
    [SerializeField] private int _AttackDamage = 10;
    [SerializeField] private AnimationClip _Attackduration;
    [SerializeField] private float _Attackcooldown = 0.5f;


    // ObserverPattern
    public Action OnAttack;
    public Action OnDash;
    public Action OnDie;

    


    public StateMachine<PlayerActor> SM { get; private set; }

    //ConcreteState
    public DashAbility DashAbility => _dashAbility;
    public Movement Movement => _movement;
    public AttackAbility AttackAbility => _attackAbility;



    // Command
    public Vector2 MoveInput { get; private set; }
    public Vector2 LastDir { get; private set; } = Vector2.right;
    public bool DashPressed { get; private set; }
    public Vector2 DashDir { get; private set; }
    public bool AttackPressed { get; private set; }


    void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _movement = new Movement(_rb, _speed);
        _dashAbility = new DashAbility(_rb, _dashForce, _dashduration, _dashcooldown);
        _attackAbility = new AttackAbility(_AttackDamage, _Attackduration.length, _Attackcooldown);


        

        SM = new StateMachine<PlayerActor>(this);
    }
    private void Start()
    {
        SM.Initialize(new PlayerFreeState());
    }
    private void Update()
    {
        SM.Tick();

        // Decrease float to dash cooldown and durantion
        _dashAbility.Tick(Time.deltaTime);
        _attackAbility.Tick(Time.deltaTime);

        // Set false to CommandPattern
        DashPressed = false;
        AttackPressed = false;
    }

    // -------- called by Commands (set intent)
    public void SetMoveInput(Vector2 input)
    {
        MoveInput = input;
        if (MoveInput != Vector2.zero) LastDir = MoveInput;
    }
    public void SetDashInput(Vector2 dir)
    {
        DashDir = dir;
        DashPressed = true;
    }
    public void PressAttack() => AttackPressed = true;

    // use with State
    public void Dash(Vector2 dir)
    {
        _dashAbility.TryDash(dir);
        OnDash?.Invoke();
    }

    public void Attack()
    {
        _attackAbility.TryAttack();
        OnAttack?.Invoke();
        Debug.Log("attack");
    }
    
}
