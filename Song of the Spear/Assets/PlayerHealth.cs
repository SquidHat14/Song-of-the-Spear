using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   //public PlayerHitDetect hitDetectorScript;
   public float maxHealth;

   private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
      //hitDetectorScript.playerDamagedEvent += TakeDamage;
      currentHealth = maxHealth;
    }

   public void TakeDamage(int damage)
   {
      currentHealth -= damage;
      if (currentHealth < 0) currentHealth = 0;
   }

   public void TakeHealing(int healing)
   {
      currentHealth += healing;
      if (currentHealth > maxHealth) currentHealth = maxHealth;
   }

   public void Die()
   {

   }
}
