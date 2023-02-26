using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseButtons : MonoBehaviour
{

    public RectTransform P1Choose;
    public RectTransform P2Choose;
    public RectTransform Button_BaLean;
    public RectTransform Button_Medrick;
    public RectTransform Button_TopG;
    public Button Player1;
    public Button Player2;
    public fighterChoose fighterChoose;

    public int XOffset;
    public int YOffset;

    public bool P1set =false;
    public bool P2set = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Player") == PlayerPrefs.GetInt("Choice1"))
        {
            Player2.interactable = false;
        }
        else
        {
            Player2.interactable = true;
        }

        if (PlayerPrefs.GetInt("Player") == PlayerPrefs.GetInt("Choice2"))
        {
            Player1.interactable = false;
        }
        else
        {
            Player1.interactable = true;
        }
    }
    public void OnP1Click()
    {
       

        if(P1set == false)
        {
            PlayerPrefs.SetInt("Choice1", PlayerPrefs.GetInt("Player"));
            P1set = true;
            if (PlayerPrefs.GetInt("Player") == 2)
            {
                P1Choose.anchoredPosition = new Vector2(Button_BaLean.anchoredPosition.x - XOffset, Button_BaLean.anchoredPosition.y - YOffset);
            }

            if (PlayerPrefs.GetInt("Player") == 3)
            {
                P1Choose.anchoredPosition = new Vector2(Button_Medrick.anchoredPosition.x - XOffset, Button_Medrick.anchoredPosition.y - YOffset);
            }

            if (PlayerPrefs.GetInt("Player") == 4)
            {
                P1Choose.anchoredPosition = new Vector2(Button_TopG.anchoredPosition.x - XOffset, Button_TopG.anchoredPosition.y - YOffset);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Choice1", 1);
            P1set = false;
            if (PlayerPrefs.GetInt("Player") == 2)
            {
                P1Choose.anchoredPosition = new Vector2(Button_BaLean.anchoredPosition.x - XOffset - 1000, Button_BaLean.anchoredPosition.y - YOffset - 1000);
            }

            if (PlayerPrefs.GetInt("Player") == 3)
            {
                P1Choose.anchoredPosition = new Vector2(Button_Medrick.anchoredPosition.x - XOffset - 1000, Button_Medrick.anchoredPosition.y - YOffset - 1000 );
            }

            if (PlayerPrefs.GetInt("Player") == 4)
            {
                P1Choose.anchoredPosition = new Vector2(Button_TopG.anchoredPosition.x - XOffset - 1000, Button_TopG.anchoredPosition.y - YOffset - 1000);
            }

        }




       


    }

    public void OnP2Click()
    {
        if (P2set == false)
        {
            PlayerPrefs.SetInt("Choice2", PlayerPrefs.GetInt("Player"));
            P2set = true;
            if (PlayerPrefs.GetInt("Player") == 2)
            {
                P2Choose.anchoredPosition = new Vector2(Button_BaLean.anchoredPosition.x - XOffset, Button_BaLean.anchoredPosition.y - YOffset);
            }

            if (PlayerPrefs.GetInt("Player") == 3)
            {
                P2Choose.anchoredPosition = new Vector2(Button_Medrick.anchoredPosition.x - XOffset, Button_Medrick.anchoredPosition.y - YOffset);
            }

            if (PlayerPrefs.GetInt("Player") == 4)
            {
                P2Choose.anchoredPosition = new Vector2(Button_TopG.anchoredPosition.x - XOffset, Button_TopG.anchoredPosition.y - YOffset);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Choice2", 0);
            P2set = false;
            if (PlayerPrefs.GetInt("Player") == 2)
            {
                P2Choose.anchoredPosition = new Vector2(Button_BaLean.anchoredPosition.x - XOffset - 1000, Button_BaLean.anchoredPosition.y - YOffset - 1000);
            }

            if (PlayerPrefs.GetInt("Player") == 3)
            {
                P2Choose.anchoredPosition = new Vector2(Button_Medrick.anchoredPosition.x - XOffset - 1000, Button_Medrick.anchoredPosition.y - YOffset - 1000);
            }

            if (PlayerPrefs.GetInt("Player") == 4)
            {
                P2Choose.anchoredPosition = new Vector2(Button_TopG.anchoredPosition.x - XOffset - 1000, Button_TopG.anchoredPosition.y - YOffset - 1000);
            }
        }

        
    }
}
