using UnityEngine;

public class Boss_MoveForThrow : StateMachineBehaviour
{
   [Header("Animator Param")]
    public string canThrowBool = "CanThrow";

    [Header("Distances")]
    public float minThrowDistance = 3.5f;
    public float maxThrowDistance = 8f;

    [Header("Retreat Once Then Throw")]
    public bool retreatOnceThenForceThrow = true;

    private BossContext _ctx;

    private bool _requestedRetreat;
    private bool _forceThrowAfterDash;
    private bool _wasDashing;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx = animator.GetComponent<BossContext>();
        _requestedRetreat = false;
        _forceThrowAfterDash = false;
        _wasDashing = false;

        animator.SetBool(canThrowBool, false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_ctx == null || _ctx.Target == null) return;

        float dist = Vector2.Distance(animator.transform.position, _ctx.Target.position);

        if (_forceThrowAfterDash && !_ctx.ChargeAttack.IsDashing)
        {
            animator.SetBool(canThrowBool, true);
            _ctx.Chase?.Stop();
            return;
        }

        if (_ctx.ChargeAttack.IsDashing)
        {
            animator.SetBool(canThrowBool, false);
            _wasDashing = true;
            return;
        }

        if (_wasDashing)
        {
            _wasDashing = false;
            _requestedRetreat = false;
        }

        if (dist >= minThrowDistance && dist <= maxThrowDistance)
        {
            animator.SetBool(canThrowBool, true);
            _ctx.Chase?.Stop();
            return;
        }

        animator.SetBool(canThrowBool, false);

        if (dist < minThrowDistance)
        {
            if (!_requestedRetreat && _ctx.ChargeAttack.CanDash)
            {
                Vector2 away = ((Vector2)animator.transform.position - (Vector2)_ctx.Target.position).normalized;
                bool didDash = _ctx.ChargeAttack.TryDash(away);
                _requestedRetreat = didDash;

                if (didDash && retreatOnceThenForceThrow)
                    _forceThrowAfterDash = true;
            }
            else
            {
                animator.SetBool(canThrowBool, true);
            }

            return;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(canThrowBool, false);
    }
}
