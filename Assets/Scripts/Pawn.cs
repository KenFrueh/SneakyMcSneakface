using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float Health = 100f;

    public Transform tf;
    void Start()
    {

       
    }
    public virtual void Attack()
    {
        Debug.Log("Pawn Attack");
    }
    public virtual void Move()
    {
        Debug.Log("Moved with pawn");
    }
}
