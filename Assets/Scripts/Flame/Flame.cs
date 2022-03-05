using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rd;
    [SerializeField] int flameDamage = 50;
    private void Start()
    {
        rd.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(flameDamage);
        }

        Destroy(gameObject);
    }

}
