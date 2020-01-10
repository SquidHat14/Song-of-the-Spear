﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnemy : MovementManagerEnemy
{
    Animator animator;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    private StopCharacter stopCharacter = new StopCharacter();

    public AudioSource audioSourceSlime;

    public Collider2D Collision2D;

    public bool StartAI;


    public bool StartMovement;

    void Start()
    {
        
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        attackTimer += Time.deltaTime;
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
        Rigidbody.velocity = new Vector2(Enemyxspeed, Enemyyspeed);
        animator.Play("SlimeBop");
        
    }
}