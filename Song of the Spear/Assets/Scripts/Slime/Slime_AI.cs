using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slime_AI : MonoBehaviour
{
   // interacting game objects //
   public Transform PlayerPosition;
   public Rigidbody2D rb;
   public CircleCollider2D HitBox;
   private float SpriteScale;
   //public GameObject player;
   //PlayerHealth playerHealth;
   float timer;
   public float TimeBetweenAttacks;
   public float MinTimeBetweenDmg;
   public float AggroRange;
   public float AttackRange;
   public float ApproachDistance;
   public float JumpSpeed_X;
   public float JumpSpeed_Y;
   public float JumpTime;
   //public GameObject AlertedAnime;
   //public Animator animate;

   // object physical properties //
   public float speed;
   private bool playerInRange;
   // 1 => right; 0 => same x position; -1 => left
   private short PlayertoRight;


   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      timer = 3;
      Debug.Log("$$$$$$$$$$$$$$$$$$$ BOUNCINESS BOUNCINESS $$$$$$$$$$$$$");
      Debug.Log(HitBox.bounciness);
      //Debug.Log(HitBox.IsTouchingLayers);
      SpriteScale = transform.localScale.x;
   }

   // Update is called once per frame
   void Update()
   {
      timer += Time.deltaTime;

      if (PlayerPosition == null)
      {
         Debug.Log("Player not found");
      }
   }

   private void FixedUpdate()
   {
      double xDist = (rb.position.x - PlayerPosition.position.x);
      double yDist = (rb.position.y - PlayerPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;

      // calculate distance to target player
      PlayertoRight = 0;
      if (xDist > 0)
      {
         PlayertoRight = -1;
      }
      else if (xDist < 0)
      {
         PlayertoRight = 1;
      }
      else
      {
         PlayertoRight = 0;
      }
      Debug.Log(SqrDistance);
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      // align sprite left / right
      if (PlayertoRight == 1)
      {
         transform.localScale = new Vector2(-SpriteScale, transform.localScale.y);
      }
      if (PlayertoRight == -1)
      {
         transform.localScale = new Vector2(SpriteScale, transform.localScale.y);
      }

      // range check
      if (DistanceToTarget < AggroRange)
      {
         playerInRange = true;
         Debug.Log("###################### Player Character found");
         Debug.Log(playerInRange);
      }

      // approaching check
      bool ApproachingPlayer = DistanceToTarget > ApproachDistance;

      Debug.Log("#########################################################");
      Debug.Log(timer);
      Debug.Log("IS  PLAYER IN RANGE??");
      Debug.Log(playerInRange);
      Debug.Log("NEED TO APPROACH TARGET");
      Debug.Log(ApproachingPlayer);
      ApproachingPlayer = false;

      // approach player
      if (DistanceToTarget > ApproachDistance && playerInRange)
      {
         transform.Translate(new Vector2(PlayertoRight, 0) * Time.deltaTime);
      }
      // attack
      else if (DistanceToTarget < AttackRange && timer >= TimeBetweenAttacks)
      {
         Debug.Log("###########################################################AAAAAAAATTTTTTTTTAAAAAACCCCKKKKK");
         Debug.Log("------------------------ TRAJECTORY ------------------------");
         Debug.Log(new Vector2(JumpSpeed_X * PlayertoRight, JumpSpeed_Y) * JumpTime);


         transform.Translate(new Vector2(JumpSpeed_X * PlayertoRight, JumpSpeed_Y) * JumpTime);
         timer = 0;
         if (HitBox.IsTouchingLayers(10))
         {
            Debug.Log("BBBBBBOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOMMMMMMMMMMMMMMMM HHHIIITTT!!");
         }
         else
         {
            Debug.Log("MMMIIIIIIIISSSSSS @@@@@@@@@@@@@@@@@@@@@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
         }
      }
   }

}