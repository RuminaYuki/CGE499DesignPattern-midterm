using UnityEngine;

public class GameManagerBossFightState : IGameManagerState
{
    public void OnEnter(GameManager ctx)
    {
        Debug.Log("GameManager Boss Fight State Entered");
    }
    public void OnUpdate(GameManager ctx)
    {
        Debug.Log("GameManager Boss Fight State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Boss Fight State Exited");
    }   
}
