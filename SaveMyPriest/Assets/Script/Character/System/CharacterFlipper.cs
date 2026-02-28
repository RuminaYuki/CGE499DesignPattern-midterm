using UnityEngine;

public class CharacterFlipper
{
    private Transform origin;
    public CharacterFlipper(Transform origin) { this.origin = origin; }
    public void FlipByLocalScale(Vector2 dir)
    {
        if (dir.x == 0) return;
        if (Mathf.Abs(dir.x) > 0.01f)
            origin.localScale = new Vector3(dir.x > 0 ? 1 : -1, 1, 1);
    }

    public void FlipByTarget(Transform target)
    {
        float dir = target.position.x - origin.position.x;
        origin.localScale = new Vector3(dir >= 0 ? 1 : -1, 1, 1);
    }
}
