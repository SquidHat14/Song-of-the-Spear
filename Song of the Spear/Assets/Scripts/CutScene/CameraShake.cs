using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Camera MainCam;
    private float ShakeAmount = 0;
    public float ShakeTime;
    CutScenePlayer ScenePlayer;
    

    private void Awake()
    {
        if(MainCam == null)
        {
            MainCam = Camera.main;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@");
            new WaitForSeconds(ShakeTime);
            Shake(0.01f, 5.5f);
        }
    
    }

    public void Shake (float amount, float length)
    {
        ShakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }
   
    private void BeginShake()
    {
        if (ShakeAmount > 0)
        {
            Vector3 CamPosition = MainCam.transform.position;

            float OffsetX = Random.value * ShakeAmount * 2 - ShakeAmount;
            float OffsetY = Random.value * ShakeAmount * 2 - ShakeAmount;
            CamPosition.x += OffsetX;
            CamPosition.y += OffsetY;

            MainCam.transform.position = CamPosition;
        }
    }

    private void StopShake()
    {
        CancelInvoke("BeginShake");
        MainCam.transform.localPosition = Vector3.zero;
    }
}
