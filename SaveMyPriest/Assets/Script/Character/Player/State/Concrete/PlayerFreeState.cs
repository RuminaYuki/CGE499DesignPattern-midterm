using UnityEngine;

public class PlayerFreeState : IPlayerState
{
    public void OnEnter(PlayerContext context)
    {
        
    }

    public void OnUpdate(PlayerContext ctx)
    {
        ctx.Movement.Move(ctx.MoveInput);
        ctx.Flipper.FlipByLocalScale(ctx.MoveInput);
        if (ctx.DashPressed == true && ctx.DashAbility.CanDash)
        {
            ctx.SM.ChangeState(new PlayerDashState());
        }
        if (ctx.AttackPressed == true && ctx.AttackAbility.CanAttack)
        {
            ctx.SM.ChangeState(new PlayerAttackState());
        }
    }

    public void OnExit(PlayerContext context)
    {
        
    }
}
