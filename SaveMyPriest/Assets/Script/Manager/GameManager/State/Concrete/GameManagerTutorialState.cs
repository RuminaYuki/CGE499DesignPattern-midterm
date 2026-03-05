using UnityEngine;

public class GameManagerTutorialState : IGameManagerState
{
    public void OnEnter(GameManager ctx)
    {
        ctx.HeathUI.SetActive(false);
        ctx.ToturialUI.SetActive(true);
        ctx.gameStateUI.SetActive(false);
        ctx.Boss.SetActive(false);
            
        Debug.Log("GameManager Begin State Entered");
    }
    public void OnUpdate(GameManager ctx)
    {
        if (ctx.IsEnterRoom)
        {
            ctx.SM.ChangeState(new GameManagerBossFightState());
            return;
        }
        //Debug.Log("GameManager Begin State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Begin State Exited");
    }
}
