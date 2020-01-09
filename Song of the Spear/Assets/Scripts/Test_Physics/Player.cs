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

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;
    public Vector3 velocity;
    public float velocityXSmoothing;

    public bool jump;

    //Vector2 input;

   public Controller2D controller;

   void Start()
    {
        controller = GetComponent<Controller2D>();

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void FixedUpdate()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (jump && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            Debug.Log("jump pressed");
            jump = false;
        }

        if (!jump && !controller.collisions.below && velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void Update()
    {
        jump = Input.GetKey("w") || Input.GetKey(KeyCode.Space);
    }

    public void SavePlayer()
    {
        //GlobalControl.Instance.jumpHeight = jumpHeight;
        //GlobalControl.Instance.timeToJumpApex = timeToJumpApex;
        //GlobalControl.Instance.accelerationTimeAirborne = accelerationTimeAirborne;
        //GlobalControl.Instance.accelerationTimeGrounded = accelerationTimeGrounded;
        //GlobalControl.Instance.moveSpeed = moveSpeed;
        //GlobalControl.Instance.gravity = gravity;
        //GlobalControl.Instance.jumpVelocity = jumpVelocity;
        //GlobalControl.Instance.minJumpVelocity = minJumpVelocity;
        //GlobalControl.Instance.velocity = velocity;
        //GlobalControl.Instance.velocityXSmoothing = velocityXSmoothing;

        SaveSystem.SavePlayer(this);
    }
}