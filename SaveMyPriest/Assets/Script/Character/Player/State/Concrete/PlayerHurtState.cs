using UnityEngine;

public class PlayerHurtState : IPlayerState
{
    float _duration;
    public void OnEnter(PlayerContext ctx)
    {
        ctx.Movement.Stop();
        _duration = ctx.HurtDuration;
    }

    public void OnUpdate(PlayerContext ctx)
    {
        _duration -= Time.deltaTime;
        if (_duration <= 0)
        {
            ctx.SM.ChangeState(new PlayerFreeState());
        }
    }

    public void OnExit(PlayerContext context)
    {
        
    }
}