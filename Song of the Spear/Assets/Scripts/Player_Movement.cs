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
    private CircleCollider2D CircleCollider;
    public AudioSource audio;

    public AudioSource audio;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        SpriteScale = transform.localScale.x;
<<<<<<< Updated upstream:Song of the Spear/Assets/Scripts/Player_Movement.cs
        CircleCollider = GetComponent<CircleCollider2D>();
=======
>>>>>>> Stashed changes:Song of the Spear/Assets/Scripts/Player_Movement.cs
        audio.Play();
        audio.Pause();
    }

    // Update is called once per frame
    void Update()
    {

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

<<<<<<< Updated upstream:Song of the Spear/Assets/Scripts/Player_Movement.cs
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x + 0.5f, transform.position.y - .5f), .001f, groundLayer);
        
        //Movement//
        rigidbody.velocity = new Vector2(speed * moveX, rigidbody.velocity.y);


       if (moveX != 0)  //Handles animations and flipping sprites
=======
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x + 0.5f, transform.position.y - .5f), .02f, groundLayer);


        rigidbody.velocity = new Vector2(speed * moveX, rigidbody.velocity.y);

        if (moveX != 0)
>>>>>>> Stashed changes:Song of the Spear/Assets/Scripts/Player_Movement.cs
        {
            if (isGrounded) audio.UnPause();
            else audio.Pause();

            transform.localScale = new Vector2(Mathf.Sign(moveX) * SpriteScale, transform.localScale.y);
        }
        else
        {
            audio.Pause();
        }

        if (moveY == 1 && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
        }
        if(AttackThisFrame)
        {
            animate.SetTrigger("Attack Button Pressed");
            AttackThisFrame = false;
        }
    }

    private void ResetAttackTrigger()
    {
        animate.ResetTrigger("Attack Button Pressed");
    }
}
