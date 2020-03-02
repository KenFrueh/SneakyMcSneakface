using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject TitleBackground;

    public GameObject TitleText;

    public GameObject GameStart;

    public GameObject GameQuit;

    public GameObject Player;

    //Tracking score
    public float Score = 0.0f;
    public float Health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
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
