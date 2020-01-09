using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemy : MonoBehaviour
{
    public AudioSource AudioScream;
    CutScenePlayer player;
    CutSceneEnemy enemy;
    public float killobjecttime;

    private void Start()
    {
        player = FindObjectOfType<CutScenePlayer>();
        enemy = FindObjectOfType<CutSceneEnemy>();
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, killobjecttime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Slime")
        {
            player.StopMovement = true;
            enemy.StartMovement = false;
            AudioScream.Play();
            player.OneAttack = true;
            player.StartInputMotion = true;
            enemy.StartAI = true;
            

        }
    }

}
