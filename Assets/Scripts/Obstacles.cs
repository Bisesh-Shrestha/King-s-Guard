using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
        }
    }
}

