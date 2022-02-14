using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator myAnimator;
    [SerializeField] float horizMovement;
    [SerializeField] float speed = 2.0f;
    
    private void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizMovement*speed,rb2d.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

}
