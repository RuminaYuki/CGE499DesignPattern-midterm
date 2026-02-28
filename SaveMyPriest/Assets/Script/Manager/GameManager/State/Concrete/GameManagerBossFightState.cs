using UnityEngine;
using System;

public class GameManagerBossFightState : IGameManagerState
{
    private Action<BossDefeatedEvent> _onBossDefeated;
    private Action<PlayerDeath> _onPlayerDeath;

    public void OnEnter(GameManager ctx)
    {
        // สร้าง handler ครั้งเดียว แล้วเก็บไว้
        _onBossDefeated = (e) => OnBossDefeated(ctx);
        EventBus.Subscribe(_onBossDefeated);

        _onPlayerDeath = (e) => OnPlayerDeath(ctx);
        EventBus.Subscribe(_onPlayerDeath);

        ctx.Boss.SetActive(true);
        Debug.Log("GameManager Boss Fight State Entered");
    }

    public void OnUpdate(GameManager ctx)
    {
        //Debug.Log("GameManager Boss Fight State Ticked");
    }

    public void OnExit(GameManager ctx)
    {
        EventBus.Unsubscribe(_onBossDefeated);
        _onBossDefeated = null;

        EventBus.Unsubscribe(_onPlayerDeath);
        _onPlayerDeath = null;

        Debug.Log("GameManager Boss Fight State Exited");
    }

    private void OnBossDefeated(GameManager ctx)
    {
        ctx.SM.ChangeState(new GameManagerWinState());
    }

    private void OnPlayerDeath(GameManager ctx)
    {
        ctx.SM.ChangeState(new GameManagerOverState());
    }
}
