using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int maxHealth = 100;
    int currentHealth;
    public bool isdead=false;
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
            isdead = true;
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        if (transform.parent != null)
        {
            GetComponentInParent<EnemyPatrol>().enabled = false;
        }
    }

    void DisableEnemy()
    {
        Destroy(this.gameObject);
    }
}
