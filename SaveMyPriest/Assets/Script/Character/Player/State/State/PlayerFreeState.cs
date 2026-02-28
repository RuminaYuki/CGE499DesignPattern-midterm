using UnityEngine;

public class PlayerFreeState : IPlayerState
{
    public void OnEnter(PlayerActor context)
    {
        
    }

    public void OnUpdate(PlayerActor ctx)
    {
        ctx.Movement.Move(ctx.MoveInput);
        if (ctx.DashPressed == true && ctx.DashAbility.CanDash)
        {
            ctx.SM.ChangeState(new PlayerDashState());
        }
        if (ctx.AttackPressed == true && ctx.AttackAbility.CanAttack)
        {
            ctx.SM.ChangeState(new PlayerAttackState());
        }
    }

    public void OnExit(PlayerActor context)
    {
        
    }
}
