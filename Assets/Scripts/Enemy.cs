using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   //Transform
    private Transform tf;
    
    //Track state of AI
    public string AIState = "Idle";
    
    //Track enemies health
    public float HitPoints;
    public float MaxHitPoints;

    //Is player is in range
    public float AttackRange;

    
    //Track health cutoff
    public float HPcutoff;

    //Track target location
    public Transform target;

    //Speed of enemy
    public float Speed = 5.0f;

    //Heal rate
    public float restingHealRate = 1.0f;


    // Start is called before the first frame update
    void Start()
    {//Getting transform
        tf = gameObject.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (AIState == "Idle")
        {   //Check behavior
            Idle();
            //Check for transition
            if (InRange())
            {
                AIState = "Seek";
            }

        }
        else if (AIState == "Rest")
        {   //State behavior
            Rest();
            //Transitions
            if (HitPoints >= HPcutoff)
            {
                ChangeState("Idle");
            }
        }
        else if (AIState == "Seek")
        {
            Seek();
            if (HitPoints < HPcutoff)
            {
                ChangeState("Rest");
            }
            if (!InRange())
            {
                ChangeState("Idle");
            }

        }
        else//Debugging states
        {
            Debug.LogError("State does not exist: " + AIState);
        }
    }
    //Idle state
    void Idle()
    {
        //Do nothing
    }
    //Resting state
    void Rest()
    {
        //Stand still
        //Heal
        HitPoints += restingHealRate * Time.deltaTime;

        HitPoints = Mathf.Min(HitPoints, MaxHitPoints);
    }
    //Seeking state
    void Seek()
    {
        //Move torwards player
        Vector3 vectorToTarget = target.position - tf.position;
        tf.position += vectorToTarget.normalized * Speed * Time.deltaTime;
    }
    //Changing states
    void ChangeState(string newState)
    {
        AIState = newState;
    }
    public bool InRange()
    {
        return Vector3.Distance(transform.position, tf.position) <= AttackRange);
    }
}
