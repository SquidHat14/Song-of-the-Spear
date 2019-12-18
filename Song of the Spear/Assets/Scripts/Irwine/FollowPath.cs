using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
   [SerializeField]
   private Transform[] routes;

   private int myRoute;

   private float tParam;

   private Vector2 myPosition;

   public float speedModifier;

   private bool coroutineAllowed;

   public Transform AITransform;
   public float spriteScale;

   void Start()
   {
      myRoute = 0;
      tParam = 0f;
      coroutineAllowed = true;
   }

   void Update()
   {
      if (coroutineAllowed)
         StartCoroutine(GoByTheRoute(myRoute));
   }

   private IEnumerator GoByTheRoute(int routeNumber)
   {
      coroutineAllowed = false;

      Vector2 p0 = routes[routeNumber].GetChild(0).position;
      Vector2 p1 = routes[routeNumber].GetChild(1).position;
      Vector2 p2 = routes[routeNumber].GetChild(2).position;
      Vector2 p3 = routes[routeNumber].GetChild(3).position;

      while (tParam < 1)
      {
         tParam += Time.deltaTime * speedModifier;

         myPosition = Mathf.Pow(1 - tParam, 3) * p0 +
            3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
            Mathf.Pow(tParam, 3) * p3;

         float xDist = transform.position.x - myPosition.x;
         // align sprite left / right
         if (xDist > 0)//R
         {
            AITransform.localScale = new Vector2(spriteScale, transform.localScale.y);
         }
         if (xDist < 0)//L
         {
            AITransform.localScale = new Vector2(-spriteScale, transform.localScale.y);
         }
         transform.position = myPosition;
         yield return new WaitForEndOfFrame();
      }

      tParam = 0f;

      myRoute += 1;

      if (myRoute > routes.Length - 1)
         myRoute = 0;

      coroutineAllowed = true;
   }
}
