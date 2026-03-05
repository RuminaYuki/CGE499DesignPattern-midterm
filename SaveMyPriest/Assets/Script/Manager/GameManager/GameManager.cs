using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // reference
    private StateMachine<GameManager> _sm;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _toturialUI;
    public GameObject gameStateUI;
    [SerializeField] private Collider2D _closeDoorCollider;
    [SerializeField] private GameObject _heathUI;
    public TextMeshProUGUI gameStateText;
    // sent to concrete state
    public StateMachine<GameManager> SM => _sm;
    public GameObject Boss => _boss;
    public GameObject ToturialUI => _toturialUI;
    public Collider2D CloseDoorCollider => _closeDoorCollider;
    public GameObject HeathUI => _heathUI;
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
        _sm.Initialize(new GameManagerTutorialState());
    }

    private void Update()
    {
        _sm.Tick();
    }

    public void SetIsEnterRoom(bool value) => _isEnterRoom = value;

    
}
