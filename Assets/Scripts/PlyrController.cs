using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrController : MonoBehaviour
{
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
    //Attack function
    void Knife()
    {
        throw new NotImplementedException();
    }
}

