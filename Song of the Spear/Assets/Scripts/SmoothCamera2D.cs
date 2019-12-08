using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{
    //public float delay = 0.15f;
    [Range(1f,3f)]
    public float speed = 2f;
    public Transform target;

    [Range(0f,3f)]
    public float yOffset;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(target)
        {
            Vector3 newPosition = target.position;
            newPosition.y += yOffset;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);

        }
    }
}
