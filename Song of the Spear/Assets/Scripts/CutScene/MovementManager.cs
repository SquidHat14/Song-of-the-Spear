using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    Animator Animator;
    public float Playerxspeed;
    public float Playeryspeed;
    public float Enemyxspeed;
    public float Enemyyspeed;
    public float waittime;
    public bool NonAnimation;
    public float TimetoWait;
    public int[] CamArr;
    

    public MovementManager()
    {
        float Xspeed = Playerxspeed;
        float Yspeed = Playeryspeed;
        bool Isanimation = NonAnimation;
        float ExSpeed = Enemyxspeed;
        float EySpeed = Enemyyspeed;
        float WaitTime = TimetoWait;
        int[] CameraArray = CamArr;
        
    }

}
