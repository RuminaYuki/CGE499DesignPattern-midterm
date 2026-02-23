using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private StateMachine<GameManager> _sm;

    protected override void Awake()
    {
        base.Awake();
        _sm = new StateMachine<GameManager>(this);
    }

    private void Start()
    {
        _sm.Initialize(new GameManagerStartState());
    }

    private void Update()
    {
        _sm.Tick();
    } 
}
