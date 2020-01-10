using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class ActivateText : MonoBehaviour
{

    public TextAsset InputText;

    public int startline;
    public int endline;

    public TextBox TheTextBox;

    public bool RequireButtonPress;
    private bool WaitforPress;

    public bool IsCollison;

    public Controller2D Controller2D;

    
    public bool DestroyWhenFinished;
    // Start is called before the first frame update
    void Start()
    {
        TheTextBox = FindObjectOfType<TextBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitforPress && Input.GetKeyDown(KeyCode.J))
        {
            TheTextBox.ReloadScript(InputText);
            TheTextBox.currentline = startline;
            TheTextBox.endline = endline;
            //TheTextBox.TextBoxEnable();

            if (DestroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(RequireButtonPress)
            {
                WaitforPress = true;
                return;
            }

            TheTextBox.ReloadScript(InputText);
            TheTextBox.currentline = startline;
            TheTextBox.endline = endline;
            //TheTextBox.TextBoxEnable();

            if(DestroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            WaitforPress = false;
        }
    }
}
