using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool IsFirstUpdate = true;

    private void Update()
    {
       if(IsFirstUpdate)
        {
            IsFirstUpdate = false;
            Loader.LoaderCallBack();

        }
    }
}
