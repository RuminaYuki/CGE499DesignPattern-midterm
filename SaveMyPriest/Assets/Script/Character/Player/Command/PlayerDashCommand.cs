using UnityEngine;

public class PlayerDashCommand : ICommand
{
    private PlayerContext _playerActor;
    private Vector2 _direction;
    public PlayerDashCommand(PlayerContext playerActor, Vector2 direction)
    {
        _playerActor = playerActor;
        _direction = direction;
    }
    public void Execute()
    {
        _playerActor.SetDashInput(_direction);
    }
}
