using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 targetPoint;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float arcHeight = 2f;

    private float progress;

    private ProjectilePool _pool;

    public void SetPool(ProjectilePool pool) => _pool = pool;

    public void Initialize(Vector3 target)
    {
        startPoint = transform.position;
        targetPoint = target;
        progress = 0f; // ✅ สำคัญมาก! ไม่งั้น reuse แล้ว t ค้าง
    }

    private void Update()
    {
        progress += speed * Time.deltaTime;
        float t = progress;

        Vector3 linearPos = Vector3.Lerp(startPoint, targetPoint, t);
        float arc = arcHeight * 4f * t * (1f - t);

        transform.position = new Vector3(linearPos.x, linearPos.y + arc, 0f);

        if (t >= 1f)
        {
            if (_pool != null) _pool.Release(this);
            else Destroy(gameObject); // เผื่อไม่ได้ใช้ pool
        }
    }
}