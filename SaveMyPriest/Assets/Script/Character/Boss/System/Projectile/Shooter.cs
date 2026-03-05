using UnityEngine;

public class ShooterFinal : MonoBehaviour
{
    [SerializeField] private ProjectilePool pool;
    [SerializeField] private Transform target;
    [SerializeField] private float shootRate = 1f;

    [Header("Mode")]
    [SerializeField] private bool autoFire = false; // ✅ ปิดไว้ถ้าจะให้ยิงตาม state

    private float shootTimer;

    private void Update()
    {
        if (!autoFire) return;

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            shootTimer = shootRate;
            FireOnce();
        }
    }

    // ✅ ยิง “หนึ่งครั้ง”
    public void FireOnce()
    {
        if (pool == null || target == null) return;

        var projectile = pool.Get(transform.position, Quaternion.identity);
        projectile.Initialize(target.position); // ล็อกตำแหน่งตอนยิงแล้ว (ไม่ตาม)
    }

    // เผื่ออยากยิงไปจุดอื่น (optional)
    public void FireOnceAt(Vector3 point)
    {
        if (pool == null) return;

        var projectile = pool.Get(transform.position, Quaternion.identity);
        projectile.Initialize(point);
    }
}