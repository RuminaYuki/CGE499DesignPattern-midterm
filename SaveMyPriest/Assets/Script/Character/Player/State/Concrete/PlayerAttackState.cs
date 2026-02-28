using UnityEngine;

public class PlayerAttackState : IPlayerState
{
    public void OnEnter(PlayerContext ctx)
    {
        ctx.Attack();
    }

    public void OnUpdate(PlayerContext ctx)
    {
        ctx.Movement.Move(ctx.MoveInput);
        if (!ctx.AttackAbility.IsAttacking)
        {
            ctx.SM.ChangeState(new PlayerFreeState());
        }
    }

    public void OnExit(PlayerContext ctx)
    {
    }
}
