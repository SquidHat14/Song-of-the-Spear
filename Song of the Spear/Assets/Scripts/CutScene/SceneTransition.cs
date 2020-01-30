using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string nextSceneName;

    public Vector2 nextSpawnPoint;

    private GameManager gamemanager;

    void Awake()
    {
        if (nextSceneName == null)
        {
            Debug.Log("Must set Scene name");
            return;
        }
    }

    void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("GameManager");
        gamemanager = gameObjects[0].GetComponent<GameManager>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        { 
            gamemanager.spawnPoint.x = nextSpawnPoint.x;
            gamemanager.spawnPoint.y = nextSpawnPoint.y;

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
