using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rd;
    private void Start()
    {
        rd.velocity = transform.right * speed;
    }
}
