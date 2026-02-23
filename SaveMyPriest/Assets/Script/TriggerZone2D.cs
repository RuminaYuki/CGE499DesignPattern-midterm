using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerZone2D : MonoBehaviour
{
    [Header("Tag of the object to detect")]
    [SerializeField] private string _tagToDetect;
    [SerializeField] private UnityEvent _onTrigger;
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        if(string.IsNullOrEmpty(_tagToDetect))
        {
            Debug.LogWarning("No tag set for TriggerZone2D on " + gameObject.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (string.IsNullOrEmpty(_tagToDetect)) return;
        if (collision.CompareTag(_tagToDetect))
        {
            _onTrigger?.Invoke();
        }
    }
}
