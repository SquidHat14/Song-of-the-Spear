using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Controller2D))]
public class CutScenePlayer : MovementManagerPlayer
{
    Animator animator;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    public float Walkspeed = 1f;
    public int TimetoStop = 1;
    private Player player;

    //new private float jumpHeight;
    //new private float timeToJumpApex;
    //new private float accelerationTimeAirborne;
    //new private float accelerationTimeGrounded;
    //new private float moveSpeed;

    //new private float gravity;
    //new private float jumpVelocity;
    //new private float minJumpVelocity;
    //new private Vector3 velocity;
    //new private float velocityXSmoothing;

    private StopCharacter stopCharacter = new StopCharacter();

    private StopEnemy StopEnemy = new StopEnemy();

    public Collider2D Collision2D;

    public AudioSource Audio;

    public bool StopMovement;

    public bool OneAttack;

    public bool StartInputMotion;


   void Start()
    {
        //jumpHeight = GlobalControl.Instance.jumpHeight;
        //timeToJumpApex = GlobalControl.Instance.timeToJumpApex;
        //accelerationTimeAirborne = GlobalControl.Instance.accelerationTimeAirborne;
        //accelerationTimeGrounded = GlobalControl.Instance.accelerationTimeGrounded;
        //moveSpeed = GlobalControl.Instance.moveSpeed;
        //gravity = GlobalControl.Instance.gravity;
        //jumpVelocity = GlobalControl.Instance.jumpVelocity;
        //minJumpVelocity = GlobalControl.Instance.minJumpVelocity;
        //velocity = GlobalControl.Instance.velocity;d
        //velocityXSmoothing = GlobalControl.Instance.velocityXSmoothing;

        Audio.Play();
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = GetComponent<Controller2D>();

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
       
    }

//    public void LoadPlayer()
//    {
//       PlayerData Data = SaveSystem.LoadPlayer();

//        jumpHeight = Data.jumpHeight;
//        timeToJumpApex = Data.timeToJumpApex;
//        accelerationTimeAirborne = Data.accelerationTimeAirborne;
//        accelerationTimeGrounded = Data.accelerationTimeGrounded;
//        moveSpeed = Data.moveSpeed;

//        gravity = Data.gravity;
//        jumpVelocity = Data.jumpVelocity;
//        minJumpVelocity = Data.minJumpVelocity;
        
//        velocity.x = Data.velocity[0];
//        velocity.y = Data.velocity[1];
//        velocity.z = Data.velocity[2];
       


//}

    // Update is called once per frame
   void FixedUpdate()
    {
        if (OneAttack)
        {
            animator.SetTrigger("Attack1");
            OneAttack = false;
        }
        if (StartInputMotion)
        {
            
            jump = Input.GetKey(KeyCode.Space);

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
        if (StopMovement)
        {
            Audio.Pause();
            animator.SetFloat("Speed", 0);
            return;
        }
        
        Rigidbody.velocity = new Vector2(Playerxspeed, Playeryspeed);   

        if (!NonAnimation)
        {
            animator.SetFloat("Speed", 2);
        }
        
        stopCharacter.OnTriggerEnter2D(Collision2D);

    }
}
