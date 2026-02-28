using UnityEngine;

public class PlayerAttackCommand : ICommand
{
    private PlayerContext _playerActor;
    public PlayerAttackCommand(PlayerContext playerActor)
    {
        _playerActor = playerActor;
    }
    public void Execute()
    {
        _playerActor.PressAttack();
    }
}
