using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManagerEnemy : Slime_AI
{
    public float Enemyxspeed;
    public float Enemyyspeed;
    public bool NonAnimation;
    public float TimetoWait;


    public MovementManagerEnemy()
    {
        float ExSpeed = Enemyxspeed;
        float EySpeed = Enemyyspeed;
        bool Isanimation = NonAnimation;
        float WaitTime = TimetoWait;
    }
}
