using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int maxHealth = 100;
    int currentHealth;
    private void Start()
    {
        MaxHealth();
    }

    public void MaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("isDead", true);
    }

    void DisableEnemy()
    {
        Destroy(this.gameObject);
    }
}
