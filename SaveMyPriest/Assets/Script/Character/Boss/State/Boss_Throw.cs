using UnityEngine;

public class Boss_Throw : StateMachineBehaviour
{

    [Header("Timing")]
    public float fireDelay = 0.1f;

    private BossContext _ctx;
    private float _delayLeft;
    private bool _fired;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ctx = animator.GetComponent<BossContext>();
        _delayLeft = fireDelay;
        _fired = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_ctx == null) return;

        if (!_fired)
        {
            _delayLeft -= Time.deltaTime;
            if (_delayLeft > 0f) return;

            _ctx.Shooter?.FireOnce();
            _fired = true;
        }
    }
}
