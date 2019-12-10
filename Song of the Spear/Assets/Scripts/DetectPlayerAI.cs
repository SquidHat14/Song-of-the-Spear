using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectPlayerAI : MonoBehaviour
{
   public Transform playerPosition;
   public Transform aiPosition;

   public float aggroRange;

   private bool playerDetected;
   private bool playerToRight;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public bool FindPlayer()
   {
      // calculate distance to player
      double xDist = (playerPosition.position.x - aiPosition.position.x);
      double yDist = (playerPosition.position.y - aiPosition.position.y);
      double SqrDistance = xDist * xDist + yDist * yDist;
      double DistanceToTarget = Math.Pow(SqrDistance, 0.5f);

      // range check
      if (DistanceToTarget < aggroRange)
      {
         playerDetected = true;
      }
      else
      {
         playerDetected = false;
      }


      return playerDetected;
   }

   public bool RightOrLeft()
   {
      double xDist = GetXDistance();

      // player to right or left
      if (xDist > 0.1)
      {
         playerToRight = true;
      }
      else if (xDist < 0.1)
      {
         playerToRight = false;
      }

      return playerToRight;
   }

   private double GetXDistance()
   {
      double xDist = (playerPosition.position.x - aiPosition.position.x);
      return xDist;
   }
}
