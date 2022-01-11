using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator myAnimator;
    [SerializeField] float speed = 2.0f;
    public float horizMovement;
    private bool facingRight = true;    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizMovement*speed,rb2d.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    private void Flip (float horizontal)
    {
        if (horizontal < 0  && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
