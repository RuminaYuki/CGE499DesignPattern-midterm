using UnityEngine;

public class BossSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] walk;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWlakSound()
    {
        int random = Random.Range(0,walk.Length);
        audioSource.PlayOneShot(walk[random]);
    }
}
