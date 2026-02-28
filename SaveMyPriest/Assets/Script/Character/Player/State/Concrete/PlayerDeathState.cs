using UnityEngine;

public class PlayerDeathState : IPlayerState
{
    public void OnEnter(PlayerContext ctx)
    {
        ctx.Movement.Stop();
        Debug.Log("Player is dead.");
    }

    public void OnUpdate(PlayerContext ctx)
    {
        
    }

    public void OnExit(PlayerContext ctx)
    {
    }
}
