using UnityEngine;

public class RandomPattern : StateMachineBehaviour
{
    public int count;
    private BossContext _ctx;
    private BossController _controller;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx = animator.GetComponent<BossContext>();
        _controller = animator.GetComponent<BossController>();

        _controller.StartRandom(count);
        animator.SetInteger("Random", _ctx.numberofPattern);
    }
}
