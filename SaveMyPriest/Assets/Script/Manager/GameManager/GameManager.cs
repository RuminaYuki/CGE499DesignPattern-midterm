using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // reference
    private StateMachine<GameManager> _sm;
    [SerializeField] private GameObject _boss;

    // sent to concrete state
    public StateMachine<GameManager> SM => _sm;
    public GameObject Boss => _boss;
    public bool IsEnterRoom => _isEnterRoom;

    // fields
    private bool _isEnterRoom;

    protected override void Awake()
    {
        base.Awake();
        _sm = new StateMachine<GameManager>(this);
    }

    private void Start()
    {
        _sm.Initialize(new GameManagerBeginState());
    }

    private void Update()
    {
        _sm.Tick();
    }

    public void SetIsEnterRoom(bool value) => _isEnterRoom = value;

    public void ReloadScene()
    {
        EventBus.Clear();
        Destroy(gameObject);
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 300, 30), "1: Defeat Boss | 2: Player Death | 3: Restart");
    }
}
