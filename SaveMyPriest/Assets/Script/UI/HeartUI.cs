using UnityEngine;

public class HeartUI : MonoBehaviour
{
    [SerializeField] Animator[] hearts;
    [SerializeField] private PlayerHeath playerHealth;

    void OnEnable()
    {
        playerHealth.OnGetHit += OnHealthChanged;
    }

    void OnAnimatorIK(int layerIndex)
    {
        
    }

    void OnHealthChanged()
    {
        int hp = Mathf.RoundToInt(playerHealth.HealthSystem.CurrentHP);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
                continue;
            else
                hearts[i].GetComponent<Animator>().SetTrigger("GetHit");
        }
    }
}
