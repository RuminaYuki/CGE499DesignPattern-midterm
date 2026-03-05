using UnityEngine;

public class GameManagerWinState : IGameManagerState
{
    public void OnEnter(GameManager ctx)
    {
        ctx.gameStateText.text = "GameWin";
        ctx.gameStateUI.SetActive(true);
    }
    public void OnUpdate(GameManager ctx)
    {
        
        Debug.Log("GameManager Win State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Win State Exited");
    }
}
