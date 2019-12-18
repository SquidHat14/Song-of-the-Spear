using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetect : MonoBehaviour
{
   //public delegate void PlayerDamaged();
   //public event PlayerDamaged playerDamagedEvent;

   private SpriteRenderer playerSprite;
   public PlayerHealth playerHealth;

   public float minTimeBetweenDmg;
   public float hitFlashTime;

   private float timeSinceDamaged;
   private float hitFlashTimer;
   private bool playerHit;

   private void Start()
   {
      playerSprite = GetComponentInParent<SpriteRenderer>();

      timeSinceDamaged = minTimeBetweenDmg;
      playerHit = false;
   }

   public void ValidateHitPlayer(int dmg)
   {
      if (!playerHit)
      {
         TakeHit(dmg);
      }
   }

   private void TakeHit(int dmg)
   {
      playerHit = true;
      timeSinceDamaged = 0;
      playerHealth.TakeDamage(dmg);

      Debug.Log("Player has been struck");
      playerSprite.color = new Color(255, 0, 0);

      //if (playerDamagedEvent != null) playerDamagedEvent();
   }

   private void FixedUpdate()
   {
      if (playerHit)
      {
         if (timeSinceDamaged > minTimeBetweenDmg)
         {
            playerHit = false;
         }
         else
         {
            timeSinceDamaged += Time.deltaTime;
         }
      }


      if (playerSprite.color == new Color(255, 0, 0))
      {
         if (hitFlashTimer < hitFlashTime) hitFlashTimer += Time.deltaTime;
         else
         {
            hitFlashTimer = 0;
            playerSprite.color = new Color(255, 255, 255);
         }
      }
   }
}
