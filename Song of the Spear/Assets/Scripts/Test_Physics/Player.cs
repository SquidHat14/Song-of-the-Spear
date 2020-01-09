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

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    bool holdingJump;
    bool alreadyJumped = true;

    //Vector2 input;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void FixedUpdate()
    {
        if (controller.collisions.above)
        {
            velocity.y = 0;
        }
        if (controller.collisions.below)
        {
            velocity.y = 0;
            coyoteTimeCurrentFrame = 0;
            alreadyJumped = false;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (holdingJump && (controller.collisions.below || (coyoteTimeCurrentFrame < coyoteTimeFrameLimit && alreadyJumped == false)))
        {
            velocity.y = jumpVelocity;
            alreadyJumped = true;
        }

        if (!holdingJump && !controller.collisions.below && velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;

        Debug.Log(coyoteTimeCurrentFrame);

        coyoteTimeCurrentFrame++;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Update()
    {
        holdingJump = Input.GetKey("w") || Input.GetKey(KeyCode.Space);
    }
}