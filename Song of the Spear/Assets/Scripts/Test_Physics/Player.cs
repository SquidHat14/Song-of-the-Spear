using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;
    public float moveSpeed = 4;

    [Range (0,15)]
    public int coyoteTimeFrameLimit = 3;
    private int coyoteTimeCurrentFrame = 0;
    private int IdleAnimationTimer = 0;
    public int IdleAnimationFrame;

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    bool holdingJump;
    float inputX;
    bool alreadyJumped = true;

    //Vector2 input;

    Controller2D controller;
    Animator animate;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        animate = GetComponent<Animator>();

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void FixedUpdate()
    {
        if (velocity.x == 0 && controller.collisions.below)
        {
            IdleAnimationTimer++;
        }
        else
        {
            IdleAnimationTimer = 0;
        }

        if (controller.collisions.above)
        {
            velocity.y = 0;
        }
        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
            coyoteTimeCurrentFrame = 0;
            alreadyJumped = false;
        }



        if (holdingJump && (controller.collisions.below || (coyoteTimeCurrentFrame < coyoteTimeFrameLimit && alreadyJumped == false)))
        {
            velocity.y = jumpVelocity;
            alreadyJumped = true;
        }

        if (!holdingJump && !controller.collisions.below && velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }

        float targetVelocityX = inputX * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;

        Debug.Log(coyoteTimeCurrentFrame);

        coyoteTimeCurrentFrame++;
        controller.Move(velocity * Time.deltaTime);

        if (IdleAnimationTimer >= IdleAnimationFrame && animate.GetCurrentAnimatorStateInfo(0).IsName("idle_animation"))  //Not sure about the layer passed in.
        {
            Debug.Log("Idle Animation Played");
            //Add trigger to play special idle animation
        }
    }
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        holdingJump = Input.GetKey("w") || Input.GetKey(KeyCode.Space);
    }
}