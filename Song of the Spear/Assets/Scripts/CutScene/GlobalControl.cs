using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;
    public float jumpHeight;
    public float timeToJumpApex;
    public float accelerationTimeAirborne;
    public float accelerationTimeGrounded;
    public float moveSpeed;

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;
    public Vector3 velocity;
    public float velocityXSmoothing;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
