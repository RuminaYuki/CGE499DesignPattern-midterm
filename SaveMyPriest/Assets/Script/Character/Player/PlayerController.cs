using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CommandManager _commandManager;
    private PlayerActor _playerActor;

    private Vector2 _lastDir;

    void Awake()
    {
        _playerActor = GetComponent<PlayerActor>();
    }

    void Update()
    {
        Move();
        Dash();
        Attack();
    }

    void Move()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        if (input == _lastDir) return;     // ไม่เปลี่ยนทิศ ไม่ต้องบันทึก

        _lastDir = input;
        _commandManager.ExecuteCommand(new PlayerMoveCommand(_playerActor, input));
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;

            _commandManager.ExecuteCommand(new PlayerDashCommand(_playerActor, input));
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _commandManager.ExecuteCommand(new PlayerAttackCommand(_playerActor));
        }
           
    }
}