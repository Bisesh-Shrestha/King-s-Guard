using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantDoubleJump : MonoBehaviour
{
    [SerializeField] PlayerJump playerJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerJump.checkdoubleJump = true;
            Destroy(gameObject);
        }
    }
}
