using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Controller2D))]
public class Slime_AI : MonoBehaviour
{
   // ### Interacting Game Objects ### //
   public Transform playerPosition;
   public Rigidbody2D rb;
   public BoxCollider2D hitBox;//unused
   private float spriteScale;
   //public GameObject player;
   //PlayerHealth playerHealth;
   //Animator AnimationController;
   //Audio Controller;


   // ##### Movement Parameters #####
   public float moveSpeed;

   private float currentVelocityX;
   private float currentVelocityY;


   // ##### Combat Parameters #####
   public float timeBetweenAttacks;
   public float minTimeBetweenDmg;//unused
   public float aggroRange;
   public float attackRange;
   public float approachDistance;

   private bool playerInRange;
   private float attackTimer;
   // 1=R; 0=ON; -1=L PFB
   private short playertoRight;


   // ##### Jumping Parameters #####
   public float accelerationTimeAirborne;
   public float accelerationTimeGrounded;
   public float jumpVelocity;
   public float jumpTime;//unused
   public float attackSpeed;

   float velocityXSmoothing;
   Vector3 velocity;


   // ##### Physics Parameters #####
   public float gravity;
   Controller2D controller;


   void Start()
   {
      // set up my rigid body, attackTimer, spritescale
      rb = GetComponent<Rigidbody2D>();
      attackTimer = timeBetweenAttacks;
      spriteScale = transform.localScale.x;

      // set up physics controller
      controller = GetComponent<Controller2D>();
   }


   // Update is called once per frame
   void Update()
   {
      attackTimer += Time.deltaTime;
   }

   // Fixed updated is called on every rendered frame???
   private void FixedUpdate()
   {
      currentVelocityX = 0;
      // calculate distance to target player
      double xDist = (rb.position.x - playerPosition.position.x);
      double yDist = (rb.position.y - playerPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      playertoRight = 0;
      if (xDist > 0.1)
      {
         playertoRight = -1;
      }
      else if (xDist < 0.1)
      {
         playertoRight = 1;
      }
      else
      {
         playertoRight = 0;
      }

      // align sprite left / right
      if (playertoRight == 1)
      {
         transform.localScale = new Vector2(-spriteScale, transform.localScale.y);
      }
      if (playertoRight == -1)
      {
         transform.localScale = new Vector2(spriteScale, transform.localScale.y);
      }

      // range check
      if (DistanceToTarget < aggroRange)
      {
         playerInRange = true;
      }

      // ####################### WIP - pre interaction AI needed ############### //
      // approach player?
      if (DistanceToTarget > approachDistance && playerInRange)
      {
         currentVelocityX = moveSpeed;
      }
      // attack or approach
      if (DistanceToTarget < attackRange && attackTimer >= timeBetweenAttacks && playerInRange)
      {
         velocity.y = jumpVelocity;
         attackTimer = 0;
         currentVelocityX = attackSpeed;
      }

      float approach = 0;
      if (playerInRange && DistanceToTarget > approachDistance) { approach = 1; }

      float targetVelocityX = currentVelocityX * playertoRight * approach;
      velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
      velocity.y += gravity * Time.deltaTime;
      controller.Move(velocity * Time.deltaTime);
   }

}