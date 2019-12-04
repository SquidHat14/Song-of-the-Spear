using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    private float SpriteScale;
    public Animator animate;
    private bool isGrounded;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    private bool AttackThisFrame;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        SpriteScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x - 0.5f, transform.position.y - .5f), .05f, groundLayer);

        if (Input.GetKeyDown("e"))
        {
            AttackThisFrame = true;
            Debug.Log("Button Pressed");
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        animate.SetFloat("Speed", Mathf.Abs(speed * moveX));

        rigidbody.velocity = new Vector2(speed * moveX, rigidbody.velocity.y);
        if (moveX == 1)
        {
            transform.localScale = new Vector2(SpriteScale, transform.localScale.y);
        }
        if (moveX == -1)
        {
            transform.localScale = new Vector2(-SpriteScale, transform.localScale.y);
        }
        if (moveY == 1 && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
        }
        if(AttackThisFrame)
        {
            animate.ResetTrigger("Attack Button Pressed");
            animate.SetTrigger("Attack Button Pressed");
            AttackThisFrame = false;
        }
    }
}
