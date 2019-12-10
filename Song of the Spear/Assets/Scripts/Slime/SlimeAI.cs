using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
   DetectPlayerAI detectPlayerScript;
   SimplePatrolAI patrolScript;
   ChasePlayerAI chasePlayerScript;

   private bool playerFound;
   private bool playerToRight;
   private float spriteScale;

   // Start is called before the first frame update
   void Start()
    {
      detectPlayerScript = GetComponent<DetectPlayerAI>();
      patrolScript = GetComponent<SimplePatrolAI>();
      chasePlayerScript = GetComponent<ChasePlayerAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void FixedUpdate()
   {
      playerFound = detectPlayerScript.FindPlayer();
      //playerToRight = detectPlayerScript.RightOrLeft();

      if (!playerFound)
      {
         patrolScript.Patrol();
      }
      else if (playerFound)
      {
         chasePlayerScript.ChasePlayer();
      }
   }
}
