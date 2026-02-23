using UnityEngine;

public class GameManagerStartState : IGameManagerState
{
    public void OnEnter(GameManager ctx)
    {
        Debug.Log("GameManager Start State Entered");
    }
    public void OnUpdate(GameManager ctx)
    {
        Debug.Log("GameManager Start State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Start State Exited");
    }
}
