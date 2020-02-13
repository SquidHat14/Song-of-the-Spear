using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public static Player instance;

    public float jumpHeight = 4;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .18f;
    public float moveSpeed = 4;

    [Range (0,15)]
    public int coyoteTimeFrameLimit = 3;
    private int coyoteTimeCurrentFrame = 0;
    private int IdleAnimCounter = 0;
    public int SpecialIdleAnimTimer;

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;

    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public bool SecondSpearOn;
    [HideInInspector]
    public bool FirstSpearOff;


    public float velocityXSmoothing;

    private bool holdingJump;
    private float inputX;
    private bool alreadyJumped = true;
    private bool inCustcene = false;

    [HideInInspector]
    public Controller2D controller;
    public SpearAnimation spearAnimation;
    Animator animate;
    float Xscale;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Player in the scene.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("FUCK");
            instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        controller = GetComponent<Controller2D>();
        animate = GetComponent<Animator>();
        Xscale = this.gameObject.transform.localScale.x;

        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("GameManager");
        GameManager gamemanager = gameObjects[0].GetComponent<GameManager>();

        this.transform.position = gamemanager.spawnPoint;
    }

    void FixedUpdate()
    {
        float targetVelocityX = inputX * moveSpeed;

        if (!inCustcene)
        {
            if (velocity.x == 0 && controller.collisions.below)
            {
                IdleAnimCounter++;
            }
            else
            {
                IdleAnimCounter = 0;
            }

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

            if (holdingJump && (controller.collisions.below || (coyoteTimeCurrentFrame < coyoteTimeFrameLimit && alreadyJumped == false)))
            {
                velocity.y = jumpVelocity;
                alreadyJumped = true;
            }

            if (!holdingJump && !controller.collisions.below && velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }

            coyoteTimeCurrentFrame++;

            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        }

        velocity.y += gravity * Time.deltaTime;


        
        controller.Move(velocity * Time.deltaTime);

        if (IdleAnimCounter >= SpecialIdleAnimTimer && animate.GetCurrentAnimatorStateInfo(0).IsName("idle_animation"))  //Check to see if special idle animation should be played after timer.
        {
            //Debug.Log("Special Idle Animation Played");
            //Add trigger to play special idle animation
        }

        animate.SetInteger("inputX", Math.Abs((int)inputX));
        animate.SetBool("InputIsRed", SecondSpearOn);
        animate.SetBool("InputIsGreen", FirstSpearOff);
        


        if (inputX < 0)
        {
            this.gameObject.transform.localScale = new Vector2(-Xscale, transform.localScale.y);
            SecondSpearOn = spearAnimation.SwitchAnimation()[0];
            FirstSpearOff = spearAnimation.SwitchAnimation()[1];
        }
        else if(inputX > 0)
        {
            this.gameObject.transform.localScale = new Vector2(Xscale, transform.localScale.y);
            SecondSpearOn = spearAnimation.SwitchAnimation()[0];
            FirstSpearOff = spearAnimation.SwitchAnimation()[1];
        }
    }
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        holdingJump = Input.GetKey("w") || Input.GetKey(KeyCode.Space);

        if(inputX == 0)
        {
            SecondSpearOn = spearAnimation.SwitchAnimation()[0];
            FirstSpearOff = spearAnimation.SwitchAnimation()[1];
        }

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void setPlayerSpeed(int speed)
    {
        inputX = speed;
    }

    public void setPlayerInputLock(bool Lock) //true -> disable input
    {
        inCustcene = Lock;
    }
}