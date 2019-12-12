using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayer : MovementManager
{
    Animator animator;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    public float Walkspeed = 1f;
    public int TimetoStop = 1;
    private StopCharacter stopCharacter = new StopCharacter();

    public Collider2D Collision2D;

    public AudioSource Audio;
    

    public bool StopMovement;

    public bool OneAttack;


    void Start()
    {

        Audio.Play();
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(OneAttack)
        {
            animator.SetTrigger("Attack1");
            OneAttack = false;
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
