using UnityEngine;

public class Boss_Chase : StateMachineBehaviour
{
    public string stopChase = "StopChase";

    private BossContext _ctx;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx = animator.GetComponent<BossContext>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_ctx == null)
        {
            Debug.LogError("BossContext is null in Boss_Chase");
            return;
        }

        if(_ctx.Chase.distanceToTarget() <= _ctx.StopDistance)
        {
            
            animator.SetBool("IsShouldStopChase",true);
            return;
        }
        _ctx.Chase.SetDirection();
        _ctx.Chase.ChaseTick();
        _ctx.Flipper.FlipByTarget(_ctx.Target);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_ctx == null)
        {
            Debug.LogError("BossContext is null in Boss_Chase");
            return;
        }
        animator.SetBool("IsShouldStopChase",false);
        _ctx.Chase.Stop();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
