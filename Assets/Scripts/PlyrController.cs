using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlyrController : MonoBehaviour
{
    public static ProgessBar instance;
    private Transform tf;//getting transform of object
    public float turnSpeed = 1.0f;//Max 110
    public float movementSpeed = 1.0f;//Max 3
    // Start is called before the first frame update
    void Start()
    {   //Load transform of gameObject
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   //Go straight
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.up * movementSpeed * Time.deltaTime;
        }//Turn right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {//Turn Left
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {//Go backwards
            tf.position += -tf.up * movementSpeed* Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Knife();
        }
    }
    public void OnCollisionEnter2D(Collision2D otherObject)//Colliding with an object 
    {
        if (otherObject.gameObject.tag == "AssassinEnemy")
        {
            GameManager.Instance.Health -= 25;

        }
        else if (GameManager.Instance.Health <= 0)
        {
            Destroy(this.gameObject);
            //Game Over Screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            //nothing
        }
    }
        //Attack function
        void Knife()
    {
        throw new NotImplementedException();
    }
}

