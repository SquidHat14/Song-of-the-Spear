using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpAttackAI : MonoBehaviour
{
   public Transform playerPosition;
   public Transform aiPosition;

   // movement
   public float attackVelocityX;
   public float jumpVelocityY;
   public float timeBetweenAttacks;
   public float approachDistance;

   private float currentVelX;

   // phsycs stuff
   Controller2D physicsController;
   public float accelerationTimeAirborne;
   public float accelerationTimeGrounded;
   public float gravity;

   float velocityXSmoothing;
   Vector3 velocity;

   private float spriteScale = 1;
   private float attackTimer;


   // Start is called before the first frame update
   void Start()
   {
      physicsController = GetComponent<Controller2D>();
   }

   public string JumpAttack()
   {
      attackTimer += Time.deltaTime;

      // calculate distance to player
      double xDist = (playerPosition.position.x - aiPosition.position.x);
      double yDist = (playerPosition.position.y - aiPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      float rightLeft = 0;

      if (DistanceToTarget > approachDistance)
      {
         if (xDist > 0)
         {
            rightLeft = 1;
         }
         else if (xDist < 0)
         {
            rightLeft = -1;
         }
         else
         {
            rightLeft = 0;
         }

         currentVelX = attackVelocityX;
      }

      if (attackTimer > timeBetweenAttacks)
      {
         velocity.y = jumpVelocityY;
         attackTimer = 0;
      }

      float targetVelocityX = currentVelX * rightLeft;
      velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (physicsController.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
      velocity.y += gravity * Time.deltaTime;

      // align sprite left / right
      if (velocity.x > 0)//R
      {
         aiPosition.localScale = new Vector2(-spriteScale, transform.localScale.y);
      }
      if (velocity.x < 0)//L
      {
         aiPosition.localScale = new Vector2(spriteScale, transform.localScale.y);
      }

      physicsController.Move(velocity * Time.deltaTime);

      return "JumpAttacking";
   }
}
