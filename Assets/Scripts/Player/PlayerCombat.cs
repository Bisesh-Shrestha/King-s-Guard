using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint; 
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 40;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("attack");
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return; 
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
