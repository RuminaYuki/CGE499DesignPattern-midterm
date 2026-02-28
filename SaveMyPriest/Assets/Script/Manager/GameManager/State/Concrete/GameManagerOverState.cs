using UnityEngine;

public class GameManagerOverState : IGameManagerState
{
	public void OnEnter(GameManager ctx)
	{
		Debug.Log("GameManager Over State Entered");
	}
    public void OnUpdate(GameManager ctx)
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ctx.ReloadScene();
            return;
        }
        Debug.Log("GameManager Over State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Over State Exited");
    }
}

