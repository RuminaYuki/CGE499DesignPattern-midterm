using UnityEngine;

public class PlayerDashState : IPlayerState
{
    public void OnEnter(PlayerActor ctx)
    {
        ctx.Dash(ctx.DashDir);
    }

    public void OnUpdate(PlayerActor ctx)
    {
        if (!ctx.DashAbility.IsDashing)
        {
            ctx.SM.ChangeState(new PlayerFreeState());
        }
    }

    public void OnExit(PlayerActor ctx) 
    {
        Debug.Log("Exit DashState");
    }
}