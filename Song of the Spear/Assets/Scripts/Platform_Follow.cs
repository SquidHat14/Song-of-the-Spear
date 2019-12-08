using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Follow : MonoBehaviour
{
    private float length, startpos;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (player.position.x);
        float dist = (player.position.x);

        transform.position = new Vector3(dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
