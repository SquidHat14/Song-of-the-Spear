using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectPlayerAI : MonoBehaviour
{
   public Transform playerPosition;
   public Transform aiPosition;

   public float aggroRange;
   public float attackRange;
   public float searchTime;

   private bool playerFound;
   private float playerSightTimer;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public string FindRange()
   {
      if (playerSightTimer > searchTime)
      {
         playerFound = false;
         playerSightTimer = 0;
         return "playerNotFound";
      }

      double xDist = (playerPosition.position.x - aiPosition.position.x);
      double yDist = (playerPosition.position.y - aiPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      if (DistanceToTarget <= attackRange)
      {
         playerFound = true;
         return "attackRange";
      }
      else if (DistanceToTarget <= aggroRange)
      {
         playerFound = true;
         return "aggroRange";
      }
      else
      {
         if (playerFound == true)
         {
            playerSightTimer += Time.deltaTime;
            return "playerLost";
         }

         return "playerNotFound";
      }
   }
}
