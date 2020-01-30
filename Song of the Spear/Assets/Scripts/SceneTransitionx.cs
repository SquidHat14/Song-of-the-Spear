using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitionx : MonoBehaviour
{
    public string next_scene;

    public Vector3 nextRoomSpawnPoint;

    // Use this for initialization

    void OnCollisionEnter2D(Collision2D Collider)
    {
        Debug.Log("Collision with SceneTransitionx Object detected");


        if (Collider.gameObject.tag == "Player")
        {
            Debug.Log("Collider = Player");
            Debug.Log("Loading next scene " + next_scene);

            SceneManager.LoadScene(next_scene);
        }

    }

}