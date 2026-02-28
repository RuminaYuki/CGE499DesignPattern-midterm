using UnityEngine;

public class PlayerAttackCommand : ICommand
{
    private PlayerActor _playerActor;
    public PlayerAttackCommand(PlayerActor playerActor)
    {
        _playerActor = playerActor;
    }
    public void Execute()
    {
        _playerActor.Attack();
    }
}
