using UnityEngine;

public class Boss_Charge : StateMachineBehaviour
{
    private BossContext _ctx;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         _ctx = animator.GetComponent<BossContext>();
         _ctx.Chase.Stop();
         _ctx.ChargeAttack.TryDash(_ctx.DirectionToPlayer());
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx.Flipper.FlipByTarget(_ctx.Target);
        if (!_ctx.ChargeAttack.IsDashing)
        {
            _ctx.Chase.Stop();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx.Chase.Stop();
    }
}
