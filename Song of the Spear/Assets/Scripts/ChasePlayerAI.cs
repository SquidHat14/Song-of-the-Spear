using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChasePlayerAI : MonoBehaviour
{
   private bool chasing;

   public Transform playerPosition;
   public Transform aiPosition;

   // movement
   public float chaseSpeed;
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


   // Start is called before the first frame update
   void Start()
   {
      physicsController = GetComponent<Controller2D>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void BeginChasing()
   {
      chasing = true;
   }

   public void ChasePlayer()
   {
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
            Debug.Log("ERRORRRRRRRR unless slime is on the player");
         }

         currentVelX = chaseSpeed;
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
   }
}
