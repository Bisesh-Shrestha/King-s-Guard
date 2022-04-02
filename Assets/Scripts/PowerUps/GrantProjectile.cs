using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantProjectile : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            projectile.checkprojectile = true;
            Destroy(gameObject);
        }
    }
}
