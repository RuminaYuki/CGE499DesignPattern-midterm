using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            EventBus.Publish(new BossDefeatedEvent()); // Test Defeat Boss
            gameObject.SetActive(false);
        }
    }
}
