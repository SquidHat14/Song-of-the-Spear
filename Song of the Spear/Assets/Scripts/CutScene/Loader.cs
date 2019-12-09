using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        SampleScene, 
        CutScene,
        CutSceneAction,
         

    }
    
    private static Action onCallBack;

   public static void Load(Scene scene)
    {
         onCallBack = () =>
        {
            SceneManager.LoadSceneAsync(scene.ToString());
        };

        SceneManager.LoadScene(Scene.CutSceneAction.ToString());
 
    }

    public static void LoaderCallBack()
    {
        if(onCallBack != null)
        {
            onCallBack();
            onCallBack = null;
        }
    }
}
