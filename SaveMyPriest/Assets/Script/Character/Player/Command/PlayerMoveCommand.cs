using UnityEngine;

public class PlayerMoveCommand : ICommand
{
    private PlayerContext _playerActor;
    private Vector2 _direction;

    public PlayerMoveCommand(PlayerContext playerActor, Vector2 direction)
    {
        _playerActor = playerActor;
        _direction = direction;
    }

    public void Execute()
    {
        _playerActor.SetMoveInput(_direction);
    }
}
