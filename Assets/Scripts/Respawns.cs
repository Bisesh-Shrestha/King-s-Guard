using UnityEngine;

public class Respawns : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] Animator animator;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemyHealth enemyHealth;
    private void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
    void Respawn()
    {
        transform.position = respawnPoint;
        animator.SetBool("isDead", false);
        playerHealth.MaxHealth();
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerJump>().enabled = true;
        GetComponent<PlayerCombat>().enabled = true;
        enemyHealth.MaxHealth();
    }

}
