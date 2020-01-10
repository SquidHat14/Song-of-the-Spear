using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetect : MonoBehaviour
{
   public PlayerHitDetect player;
   public int damageGiven;

    // Start is called before the first frame update
    void Start()
    {
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         player.ValidateHitPlayer(damageGiven);
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         player.ValidateHitPlayer(damageGiven);
      }
   }
}
