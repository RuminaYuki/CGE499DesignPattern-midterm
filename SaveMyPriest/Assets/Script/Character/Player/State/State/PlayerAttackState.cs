using UnityEngine;

public class PlayerAttackState : IPlayerState
{
    public void OnEnter(PlayerActor ctx)
    {
        ctx.Attack();
        Debug.Log("attack Enter");
    }

    public void OnUpdate(PlayerActor ctx)
    {
        if (!ctx.AttackAbility.IsAttacking)
        {
            ctx.SM.ChangeState(new PlayerFreeState());
        }
    }

    public void OnExit(PlayerActor ctx)
    {

    }
}
