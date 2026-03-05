using UnityEngine;

public class Repoision : MonoBehaviour
{
    public Transform target;
    private Vector3 currentPoision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoision = target.position;
    }

    public void ResetPosion()
    {
        target.position = currentPoision;
    }
}
