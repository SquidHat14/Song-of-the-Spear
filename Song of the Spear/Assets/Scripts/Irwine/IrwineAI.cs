using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrwineAI : MonoBehaviour
{
   DetectPlayerAI detectPlayerScript;
   FlyingPatrolAI patrolScript;
   FlyChaseLineAI chasePlayerScript;

   private float spriteScale;
   private string AIState;
   private string CurrentRange;

   // Start is called before the first frame update
   void Start()
   {
      detectPlayerScript = GetComponent<DetectPlayerAI>();
      patrolScript = GetComponent<FlyingPatrolAI>();
      chasePlayerScript = GetComponent<FlyChaseLineAI>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   void FixedUpdate()
   {
      //Debug.Log(AIState);
      Debug.Log(CurrentRange);

      CurrentRange = detectPlayerScript.FindRange();

      if (CurrentRange == "playerNotFound")
      {
         AIState = patrolScript.Patrol();
      }
      else if (CurrentRange == "aggroRange")
      {
         AIState = chasePlayerScript.ChasePlayer();
      }
      else if (CurrentRange == "playerLost")
      {
         //AIState = chasePlayerScript.ChasePlayer();
      }

   }
}
