using Unity.VisualScripting;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWalkSound()
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(walkSound);
    }   
    public void PlayDashSound()
    {
        audioSource.PlayOneShot(dashSound);
    }
    public void PlayAttackSound()
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(attackSound);
    }
    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
