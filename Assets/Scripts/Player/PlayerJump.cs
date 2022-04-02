using UnityEngine;
public class PlayerJump : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator myAnimator;

    [Header("Jump Details")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedjumping;
    private bool doubleJump;
    public bool checkdoubleJump=false;

    [Header("Ground Details")]
    private bool grounded;
    [SerializeField] Transform checkGround;
    [SerializeField] float radOCircle;
    [SerializeField] LayerMask isGround;

    private void Start()
    {
        jumpTimeCounter = jumpTime;
        doubleJump = false;
    }
    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, radOCircle, isGround);
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("falling", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded || doubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                stoppedjumping = false;
                myAnimator.SetTrigger("jump");
                if (checkdoubleJump)
                {
                    doubleJump = !doubleJump;
                }                
            }
        }
        if (grounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButton("Jump") && !stoppedjumping && (jumpTimeCounter > 0))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedjumping = true;
            myAnimator.SetBool("falling", true);
            myAnimator.ResetTrigger("jump");
        }

        if (rb2d.velocity.y < 0)
        {
            myAnimator.SetBool("falling", true);

        }
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkGround.position, radOCircle);
    }
    private void HandleLayers()
    {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
