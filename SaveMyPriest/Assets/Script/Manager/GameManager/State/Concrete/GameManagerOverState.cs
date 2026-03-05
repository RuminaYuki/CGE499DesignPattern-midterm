using UnityEngine;

public class GameManagerOverState : IGameManagerState
{
	public void OnEnter(GameManager ctx)
	{
        ctx.gameStateText.text = "GameOver";
        ctx.gameStateUI.SetActive(true);
	}
    public void OnUpdate(GameManager ctx)
    {
       
        Debug.Log("GameManager Over State Ticked");
    }
    public void OnExit(GameManager ctx)
    {
        Debug.Log("GameManager Over State Exited");
    }
}

