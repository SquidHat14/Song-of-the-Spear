using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManagerPlayer : Player
{
    public float Playerxspeed;
    public float Playeryspeed;
    public float waittime;
    public bool NonAnimation;
    public float TimetoWait;
    public int[] CamArr;
    

    public MovementManagerPlayer()
    {
        float Xspeed = Playerxspeed;
        float Yspeed = Playeryspeed;
        bool Isanimation = NonAnimation;
        float WaitTime = TimetoWait;
        int[] CameraArray = CamArr;
        
    }

}
