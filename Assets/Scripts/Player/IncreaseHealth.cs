using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.MaxHealth();
        }
    }    
}
