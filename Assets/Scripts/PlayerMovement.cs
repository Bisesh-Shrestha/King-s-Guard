using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator myAnimator;
    public float horizMovement;
    [SerializeField] float speed = 2.0f;
    private bool facingRight = true;

    public float jumpForce;
    public bool grounded;    
    [SerializeField] Transform checkGround;
    [SerializeField] float radOCircle;
    [SerializeField] LayerMask isGround;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal");
        grounded = Physics2D.OverlapCircle(checkGround.position,radOCircle,isGround);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkGround.position, radOCircle);
    }
}
