using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile prefab;
    [SerializeField] private int preloadCount = 20;

    private readonly Queue<Projectile> _pool = new();

    private void Awake()
    {
        Preload(preloadCount);
    }

    private void Preload(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var p = Instantiate(prefab, transform);
            p.gameObject.SetActive(false);
            p.SetPool(this);
            _pool.Enqueue(p);
        }
    }

    public Projectile Get(Vector3 position, Quaternion rotation)
    {
        if (_pool.Count == 0)
            Preload(Mathf.Max(1, preloadCount / 2)); // ของหมดก็เติมเพิ่ม

        var p = _pool.Dequeue();
        p.transform.SetPositionAndRotation(position, rotation);
        p.gameObject.SetActive(true);
        return p;
    }

    public void Release(Projectile p)
    {
        p.gameObject.SetActive(false);
        p.transform.SetParent(transform);
        _pool.Enqueue(p);
    }
}