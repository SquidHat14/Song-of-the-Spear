using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public GameObject textBox;

    public Text ActualText;
    public TextAsset BigText;
    public string[] LinesofText;

    
    public int currentline;
    public int endline;

    public Player_Movement Player;

    private bool IsTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

   
    public bool IsActive;

    public int TextMoveTime;

    private bool AutoScroll;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        Player = FindObjectOfType<Player_Movement>();

        if (BigText != null)
        {
            LinesofText = BigText.text.Split('\n');
        }

        if (endline == 0)
        {
            endline = LinesofText.Length - 1;
        }
        if(IsActive)
        {
            TextBoxEnable();
        }
        else
        {
            TextBoxDisable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!IsActive)
        {
            return;
        }
         
            if(!IsTyping)
            {
                new WaitForSeconds(TextMoveTime);

                currentline += 1;

                if (currentline > endline)
                {
                    TextBoxDisable();
                    ActualText.text = "";
                }
                else
                {
                    StartCoroutine(ScrollText(LinesofText[currentline]));
                }
            }
           else if(IsTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
          
    }

    private IEnumerator ScrollText(string Dalines)
    {
        int Letter = 0;
        ActualText.text = "";
        IsTyping = true;
        cancelTyping = false;
        foreach (char letter in LinesofText[currentline])
        {
            ActualText.text += letter;
            Letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        ActualText.text = Dalines;
        IsTyping = false;
        cancelTyping = false;
    }

    public void TextBoxEnable()
    {
        textBox.SetActive(true);
        IsActive = true;

        StartCoroutine(ScrollText(LinesofText[currentline]));

    }
    public void TextBoxDisable()
    {
        textBox.SetActive(false);
        IsActive = false;

        
    }

    public void ReloadScript(TextAsset text)
    {
        if (text != null)
        {
            LinesofText = new string[1];
            LinesofText = text.text.Split('\n');
        }
    }
}
