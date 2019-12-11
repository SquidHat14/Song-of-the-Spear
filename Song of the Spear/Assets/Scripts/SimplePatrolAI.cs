using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrolAI : MonoBehaviour
{
   // movement
   public float moveSpeed;
   public float patrolSchedule;

   private float currentVelX;
   private float patrolTimer;

   //private Transform LeftEndPoint;
   //private Transform RightEndPoint;

   // phsycs stuff
   Controller2D physicsController;
   public float accelerationTimeAirborne;
   public float accelerationTimeGrounded;
   public float gravity;

   float velocityXSmoothing;
   Vector3 velocity;

   public Transform AITransform;
   private float spriteScale = 1;


   // Start is called before the first frame update
   void Start()
    {
      physicsController = GetComponent<Controller2D>();
   }

   public string Patrol()
   {      
      if (patrolTimer < patrolSchedule/2)
      {
         currentVelX = -moveSpeed;
      }
      else if (patrolTimer < patrolSchedule)
      {
         currentVelX = moveSpeed;
      }
      else
      {
         patrolTimer = 0;
      }

      patrolTimer += Time.deltaTime;

      float targetVelocityX = currentVelX;
      velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (physicsController.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
      velocity.y += gravity * Time.deltaTime;

      // align sprite left / right
      if (velocity.x > 0)//R
      {
         AITransform.localScale = new Vector2(-spriteScale, transform.localScale.y);
      }
      if (velocity.x < 0)//L
      {
         AITransform.localScale = new Vector2(spriteScale, transform.localScale.y);
      }

      physicsController.Move(velocity * Time.deltaTime);

      return "patrolling";
   }
}
