using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] Animator animator;

    [SerializeField] HealthBar healthBar;
    private void Start()
    {
        MaxHealth();
    }

    public void MaxHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
    }
}
