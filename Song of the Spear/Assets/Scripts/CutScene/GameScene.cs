using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Loader.Load(Loader.Scene.CutSceneAction);
        }
    }
}
