using UnityEngine;

public class GameManagerWinState : IGameManagerState
{
    public void OnEnter(GameManager ctx)
    {
        Debug.Log("GameManager Win State Entered");
    }
    public void OnUpdate(GameManager ctx)
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ctx.ReloadScene();
            return;
        }
        Debug.Log("GameManager Win State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Win State Exited");
    }
}
