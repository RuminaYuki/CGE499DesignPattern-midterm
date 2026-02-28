using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerContext))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CommandManager _commandManager;

    private PlayerContext _playerActor;

    private InputSystem_Actions _input;
    private Vector2 _move;        // ค่า input ปัจจุบัน
    private Vector2 _lastDir;     // ค่า input ล่าสุดที่เคยส่ง command

    private void Awake()
    {
        _playerActor = GetComponent<PlayerContext>();
        _input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // เปิด Action Map Player
        _input.Player.Enable();

        // Move ต้องรับทั้ง performed + canceled เพื่อให้ปล่อยแล้วกลับเป็น (0,0)
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled  += OnMove;

        // ปุ่มยิงครั้งเดียวใช้ performed
        _input.Player.Attack.performed += OnAttack;
        _input.Player.Dash.performed   += OnDash;
    }

    private void OnDisable()
    {
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled  -= OnMove;

        _input.Player.Attack.performed -= OnAttack;
        _input.Player.Dash.performed   -= OnDash;

        _input.Player.Disable();
    }

    private void Update()
    {
        // ส่ง Move command เมื่อทิศเปลี่ยน (เหมือนของเดิม)
        Vector2 dir = _move.normalized;

        if (dir == _lastDir) return;

        _lastDir = dir;
        _commandManager.ExecuteCommand(new PlayerMoveCommand(_playerActor, dir));
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        _move = ctx.ReadValue<Vector2>();
    }

    private void OnDash(InputAction.CallbackContext ctx)
    {
        // dash ตอนกดครั้งเดียว
        Vector2 dir = _move.sqrMagnitude > 0 ? _move.normalized : _lastDir;

        _commandManager.ExecuteCommand(new PlayerDashCommand(_playerActor, dir));
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        _commandManager.ExecuteCommand(new PlayerAttackCommand(_playerActor));
    }
}