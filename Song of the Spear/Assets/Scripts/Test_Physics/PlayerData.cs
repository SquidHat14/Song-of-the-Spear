using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float jumpHeight;
    public float timeToJumpApex;
    public float accelerationTimeAirborne;
    public float accelerationTimeGrounded;
    public float moveSpeed;

    public float gravity;
    public float jumpVelocity;
    public float minJumpVelocity;
    public float[] velocity;
    public float velocityXSmoothing;

    public PlayerData(Player player)
    {
        jumpHeight = player.jumpHeight;
        timeToJumpApex = player.timeToJumpApex;
        accelerationTimeAirborne = player.accelerationTimeAirborne;
        accelerationTimeGrounded = player.accelerationTimeGrounded;
        moveSpeed = player.moveSpeed;

        gravity = player.gravity;
        jumpVelocity = player.jumpVelocity;
        minJumpVelocity = player.minJumpVelocity;
        velocity[0] = player.velocity.x;
        velocity[1] = player.velocity.y;
        velocity[2] = player.velocity.z;
    }
}
