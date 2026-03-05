using UnityEngine;

public class TargetPointFollower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;   // Player transform
    [SerializeField] private Transform monster;  // Boss/Enemy transform

    [Header("Offset")]
    [SerializeField] private float xOffset = 1.5f;
    [SerializeField] private float yOffset = 0.0f;

    void Awake()
    {
        if (player == null)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void LateUpdate()
    {
        if (player == null || monster == null) return;

        // มอนอยู่ซ้ายของผู้เล่น -> TargetPoint ไปซ้าย (xOffset ติดลบ)
        float dx = monster.position.x - player.position.x;
        float side = (dx < 0f) ? -1f : 1f;

        transform.position = new Vector3(
            player.position.x + side * xOffset,
            player.position.y + yOffset,
            transform.position.z
        );
    }
}