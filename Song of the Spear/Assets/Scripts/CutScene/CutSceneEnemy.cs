using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    public float Walkspeed = -1f;
    // Start is called before the first frame update
    public int TimetoStop = 1;
    private StopCharacter stopCharacter = new StopCharacter();

    public AudioSource audioSourceSlime;

    public Collider2D Collision2D;

    public bool StartMovement;

    void Start()
    {
        
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        stopCharacter.OnTriggerEnter2D(Collision2D);
        if (!StartMovement)
        {
            audioSourceSlime.Pause();
            return;
        }
        audioSourceSlime.Play();
        Rigidbody.velocity = new Vector2(Walkspeed, Rigidbody.velocity.y);
        animator.Play("SlimeBop");
        
    }
}