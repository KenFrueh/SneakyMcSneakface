using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    //Getting camera follow
    public FollowPlayerCam cameraFollow;
    public Transform playerTransform;

    //Tracking score
    public float Score = 0.0f;
    public float Health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //Following the player with camera
        cameraFollow.Setup(() => playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }//Quit game
}
