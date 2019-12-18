using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
   DetectPlayerAI detectPlayerScript;
   SimplePatrolAI patrolScript;
   ChasePlayerAI chasePlayerScript;
   JumpAttackAI jumpAttackScript;

   private float spriteScale;
   private string slimeState;
   private string slimeRange;

   // Start is called before the first frame update
   void Start()
    {
      detectPlayerScript = GetComponent<DetectPlayerAI>();
      patrolScript = GetComponent<SimplePatrolAI>();
      chasePlayerScript = GetComponent<ChasePlayerAI>();
      jumpAttackScript = GetComponent<JumpAttackAI>();
   }

   // Update is called once per frame
   void Update()
    {
        
    }

   void FixedUpdate()
   {
      //Debug.Log(slimeState);
      //Debug.Log(slimeRange);

      slimeRange = detectPlayerScript.FindRange();

      if (slimeRange == "playerNotFound")
      {
         slimeState = patrolScript.Patrol();
      }
      else if (slimeRange == "aggroRange")
      {
         slimeState = chasePlayerScript.ChasePlayer();
      }
      else if (slimeRange == "attackRange")
      {
         slimeState = jumpAttackScript.JumpAttack();
      }
      else if (slimeRange == "playerLost")
      {
         slimeState = chasePlayerScript.ChasePlayer();
      }

   }
}
