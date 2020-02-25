using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleBackground;
    public GameObject TitleText;
    public GameObject GameStart;
    public GameObject GameQuit;
    //Tracking score
    public int Score = 0;
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }//Quit game
    public void OnApplicationQuit()
    {
        Application.Quit();
    }//Start game
    public void StartGame()
    {
        TitleBackground.SetActive(false);
        TitleText.SetActive(false);
        GameStart.SetActive(false);
        GameQuit.SetActive(false);
    }
}
