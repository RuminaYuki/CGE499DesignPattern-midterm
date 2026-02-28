using System;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerContext : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] private float _speed = 5f;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 10f;
    [SerializeField] private int _dashDamage = 1;
    [SerializeField] private float _dashduration = 0.15f;
    [SerializeField] private float _dashcooldown = 0.5f;

    [Header("Attack")]
    [SerializeField] private int _AttackDamage = 2;
    [SerializeField] private AnimationClip _Attackduration;
    [SerializeField] private float _Attackcooldown = 0.5f;

    [Header("Hurt")]
    [SerializeField] private AnimationClip _hurtDuration;

    //reference
    private Rigidbody2D _rb;
    private PlayerHeathManager _healthManager;

    //ObserverPattern
    public Action OnAttack;
    public Action OnDash;

    //StateMachine
    public StateMachine<PlayerContext> SM { get; private set; }

    //ConcreteState
    public float HurtDuration => _hurtDuration.length;
    public DashAbility DashAbility {get; private set;}
    public Movement Movement {get; private set;}
    public AttackAbility AttackAbility {get; private set;}
    public CharacterFlipper Flipper {get; private set;}

    // Command
    public Vector2 MoveInput { get; private set; }
    public Vector2 LastDir { get; private set; } = Vector2.right;
    public bool DashPressed { get; private set; }
    public Vector2 DashDir { get; private set; }
    public bool AttackPressed { get; private set; }


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Movement = new Movement(_rb, _speed);
        DashAbility = new DashAbility(_rb, _dashForce, _dashDamage, _dashduration, _dashcooldown);
        AttackAbility = new AttackAbility(_AttackDamage, _Attackduration.length, _Attackcooldown);
        Flipper = new CharacterFlipper(transform);
        _healthManager = GetComponent<PlayerHeathManager>();

        SM = new StateMachine<PlayerContext>(this);
    }
    void OnEnable()
    {
        _healthManager.OnGetHit += ChangeHurtState;
        _healthManager.HealthSystem.OnDied += ChangeDeathState;
    }

    void OnDisable()
    {
        _healthManager.OnGetHit -= ChangeHurtState;
        _healthManager.HealthSystem.OnDied -= ChangeDeathState;
    }

    private void Start()
    {
        SM.Initialize(new PlayerFreeState());
    }
    private void Update()
    {
        SM.Tick();

        // Decrease float to dash cooldown and durantion
        DashAbility.Tick(Time.deltaTime);
        AttackAbility.Tick(Time.deltaTime);

        // Set false to CommandPattern
        DashPressed = false;
        AttackPressed = false;
    }

    // ---------------------- called by Commands (set intent)-----------------------
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


    // -------------------------------use with State -------------------------------
    public void Dash(Vector2 dir)
    {
        DashAbility.TryDash(dir);
        OnDash?.Invoke();
    }

    public void Attack()
    {
        AttackAbility.TryAttack();
        OnAttack?.Invoke();
    }
    
    // Change state immediately when get hit, not wait for the end of current state
    public void ChangeHurtState()
    {
        Debug.Log($"Player get hit, current HP: {_healthManager.HealthSystem.CurrentHP}");
        if(_healthManager.HealthSystem.IsDead) return;
        SM.ChangeState(new PlayerHurtState());
    }

    public void ChangeDeathState()
    {
        SM.ChangeState(new PlayerDeathState());
    }
}
