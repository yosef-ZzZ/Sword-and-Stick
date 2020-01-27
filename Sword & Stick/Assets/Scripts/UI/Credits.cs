using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Image gameComplete;
    public Text text1, text2;
    private bool on = false;
    private bool active = false;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CompleteDisappear", 5f);
        TextDisappear();
    }

    // Update is called once per frame
    void Update()
    {
    switch(count)
    {
       case 0: text1.text = "Lead Programmer";
                text2.text = "Yosef Zebene";
                break;
    case 1:text1.text = "Art Director";
                text2.text = "Darwin Alvarez";
                break;
    case 2:text1.text = "Chief Asset Manager";
                text2.text = "Isaac Aserra";
                break;
    case 3:text1.text = "Slime Boss Creator";
                text2.text = "Darwin Alvarez";
                break;
    case 4:text1.text = "Level Designer";
                text2.text = "Isaac Aserra";
                break;
    case 5:text1.text = "Boss Following AI";
                text2.text = "Aiden Penner";
                break;
    case 6:text1.text = "Character Animator";
                text2.text = "Isaac Aserra";
                break;
    case 7:text1.text = "Most Broken Laptop";
                text2.text = "Darwin Alvarez";
                break;
    case 8:text1.text = "Tallest In The Group";
                text2.text = "Isaac Aserra";
                break;
    case 9:text1.text = "Thanks";
                text2.text = "For Playing!";
                break;
    case 10: SceneManager.LoadScene(0);
                break;

    }
     if(gameComplete.enabled==false)
     {
        if (on)
        {
            Invoke("TextDisappear", 3f);
        }
        else
        {
            Invoke("TextAppear", 3f);
        }
    }
    }

    void TextDisappear()
    {
    if(active)
    {
        count++;
    }

        text1.enabled = false;
        text2.enabled = false;
        on = false;
        active = false;
    }

    void TextAppear()
    {
        text1.enabled = true;
        text2.enabled = true;
        on = true;
        active = true;
    }

    void CompleteDisappear()
    {
        gameComplete.enabled=false;
    }
}
