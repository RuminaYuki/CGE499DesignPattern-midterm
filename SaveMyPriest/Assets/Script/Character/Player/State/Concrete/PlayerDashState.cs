using UnityEngine;

public class PlayerDashState : IPlayerState
{
    public void OnEnter(PlayerContext ctx)
    {
        ctx.Movement.Stop();
        ctx.Dash(ctx.DashDir);
    }

    public void OnUpdate(PlayerContext ctx)
    {
        if (!ctx.DashAbility.IsDashing)
        {
            ctx.SM.ChangeState(new PlayerFreeState());
        }
    }

    public void OnExit(PlayerContext ctx) 
    {
        ctx.Movement.Stop();
    }
}