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
        animator.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerJump>().enabled = false;
            GetComponent<PlayerCombat>().enabled = false;
            animator.SetBool("isDead", true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}
