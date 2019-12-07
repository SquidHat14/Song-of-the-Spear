using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    private float SpriteScale;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        SpriteScale = transform.localScale.x;
    }

    private void Update()
    {
        base.Update();
        InputDetect();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)  //Jumping physics
        {
            velocity.y = jumpTakeOffSpeed;
            
        }
        else if (Input.GetButtonUp("Jump"))  //Controlling how the character acts when in mid jump but letting go of Jump key
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.7f;
            }
        }

        if (move.x < 0)  //Handles animations and flipping sprites
        {
            spriteRenderer.flipX = true; //Facing Left
        }

        if (move.x > 0)  //Handles animations and flipping sprites
        {
            spriteRenderer.flipX = false; //Facing Right
        }

        //animator.SetBool("grounded", grounded);
        animator.SetFloat("" +
            "Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
        //Debug.Log("x: " + targetVelocity.x + "    y: " + targetVelocity.y);

    }

    public void ResetAttackTrigger()
    {
        animator.ResetTrigger("Attack1");
    }

    protected void InputDetect()
    {
        bool attack = Input.GetKeyDown("e");
        bool interact = Input.GetKeyDown("q");

        if(attack)
        {
            animator.SetTrigger("Attack1");
            return;
        }

        if(interact)
        {
            animator.ResetTrigger("React");
            animator.SetTrigger("React");
            return;
        }
    }
}