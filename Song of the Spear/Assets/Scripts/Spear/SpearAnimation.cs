using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAnimation : MonoBehaviour
{
    [HideInInspector]
    public int SpearSwitch;
    Animator animate;

    void Start()
    {
        animate = GetComponent<Animator>();
    }

    //public List<bool> SwitchAnimation()
    //{

    //    if (Input.GetKey(KeyCode.Alpha1))
    //    {
    //        List<bool> SpearOrder = new List<bool>();
    //        SpearOrder.Add(true);
    //        SpearOrder.Add(false);
    //        return SpearOrder;

    //    }
    //    if (Input.GetKey(KeyCode.Alpha2))
    //    {
    //        List<bool> SpearOrder = new List<bool>();
    //        SpearOrder.Add(false);
    //        SpearOrder.Add(true);
    //        return SpearOrder;
    //    }
    //    List<bool> DefaultSpearOrder = new List<bool>();
    //    DefaultSpearOrder.Add(false);
    //    DefaultSpearOrder.Add(false);
    //    return DefaultSpearOrder;
    //}

    
     void FixedUpdate()
    {
        animate.SetInteger("SpearSwitch", SpearSwitch);

        
            if(Input.GetKey(KeyCode.Alpha1))
            {
               SpearSwitch = 1;
                
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                SpearSwitch = 2;
               
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                SpearSwitch = 3;
                
            }
            else
            {
                
            }
    }

}
