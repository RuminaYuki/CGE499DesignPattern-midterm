using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private CommandManager _commandManager;

    private BossContext _bosscontext;

    [Header("RandomPattern")]
    public bool avoidRepeat = true;
    public int count = 4;

    private int _last = -1;
    private bool _isReplaying;

    private void Awake()
    {
        _bosscontext = GetComponent<BossContext>();
        _isReplaying = false;
    }

    private void OnEnable()
    {
        EventBus.Subscribe<ReplayingEvent>(SetIsReplay);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<ReplayingEvent>(SetIsReplay);
    }

    public int RandomPattern()
    {
        int value;

        if (!avoidRepeat || count == 1)
        {
            value = UnityEngine.Random.Range(0, count);
        }
        else
        {
            // สุ่มแล้วไม่ให้ซ้ำตัวเดิม
            value = UnityEngine.Random.Range(0, count - 1);

            if (_last != -1 && value >= _last)
                value++;
        }

        _last = value;
        return value;
    }

    public void StartRandom(int count)
    {
        if(_isReplaying)
        {
            Debug.Log(_isReplaying);
            return;
        }
        this.count = count;

        _commandManager.ExecuteCommand(
            new BossRandomPatternCommand(_bosscontext, RandomPattern())
        );
    }

    private void SetIsReplay(ReplayingEvent e)
    {
        _isReplaying = true;
    }
}
