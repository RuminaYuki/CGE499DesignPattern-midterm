using UnityEngine;

public class PlayerDashCommand : ICommand
{
    private PlayerActor _playerActor;
    private Vector2 _direction;
    public PlayerDashCommand(PlayerActor playerActor, Vector2 direction)
    {
        _playerActor = playerActor;
        _direction = direction;
    }
    public void Execute()
    {
        _playerActor.Dash(_direction);
    }
}
