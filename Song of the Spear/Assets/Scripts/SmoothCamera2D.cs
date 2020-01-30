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

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;



    void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("GameManager");
        GameManager gamemanager = gameObjects[0].GetComponent<GameManager>();

        this.transform.position = gamemanager.spawnPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target)
        {
            Vector3 newPosition = target.position;
            newPosition.y += yOffset;
            newPosition.z = -10;

            Vector3 temp;
            temp = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);

            transform.position = new Vector3(
            Mathf.Clamp(temp.x, minX, maxX),
            Mathf.Clamp(temp.y, minY, maxY),
            Mathf.Clamp(temp.z, minZ, maxZ));
           

        }
    }
}
