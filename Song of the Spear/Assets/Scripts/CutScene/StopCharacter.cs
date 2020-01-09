using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCharacter : MonoBehaviour
{

    CutScenePlayer player;
    CutSceneEnemy enemy;
    internal bool CShake;
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
        if(collision.name == "Player")
        {
            player.StopMovement = true;
            enemy.StartMovement = true;
            CShake = true;
            
        }
    }

    
    
}
