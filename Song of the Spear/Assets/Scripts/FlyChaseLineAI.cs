using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlyChaseLineAI : MonoBehaviour
{
   public Transform playerPosition;
   public Transform aiPosition;

   // movement
   public float chaseSpeed;
   public float approachDistance;

   private float currentVelX;
   private float currentVelY;

   // phsycs stuff
   Controller2D physicsController;
   public float accelerationTimeAirborne;
   public float accelerationTimeGrounded;
   public float gravity;

   float velocityXSmoothing;
   Vector3 velocity;

   public float spriteScale;


   // Start is called before the first frame update
   void Start()
   {
      physicsController = GetComponent<Controller2D>();
   }

   public string ChasePlayer()
   {
      // calculate distance to player
      double xDist = (playerPosition.position.x - aiPosition.position.x);
      double yDist = (playerPosition.position.y - aiPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      if (DistanceToTarget > approachDistance)
      {

         float xComponent = (float)(xDist / DistanceToTarget);
         float yComponent = (float)(yDist / DistanceToTarget);

         currentVelX = chaseSpeed * xComponent;
         currentVelY = chaseSpeed * yComponent;
         velocity.y = currentVelY;
      }

      float targetVelocityX = currentVelX;
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

      return "chasingPlayer";
   }
}
