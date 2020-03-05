using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   //Transform
    private Transform tf;
    //Turn rate
    private float turnSpeed = 110.0f;
    //Track state of AI
    public string AIState = "Idle";
    
    //Track enemies health
    public float HitPoints;
    public float MaxHitPoints;

    //Is player is in range
    public float AttackRange;
    public float FieldOfView = 45f;

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
        canHear(GameManager.Instance.Player);
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
        RotateTowards(target, false);
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
        return (Vector3.Distance(transform.position, tf.position) <= AttackRange);
    }//Hearing player

    public bool canHear(GameObject target)
    {
        //Get NoiseMaker from target
        NoiseMaker noise = target.GetComponent<NoiseMaker>();
        //if there is a noisemaker we could potentailly hear the target
        if (noise != null)
        {
            float adjustedVolumeDis = noise.volumeDist - Vector3.Distance(tf.position, target.transform.position);
            //if we're close enough hear noise
            if (adjustedVolumeDis > 0)
            {
                Debug.Log("We can Hear you");
                return true;
            }
        }
        return false;


    }//Seeing player
    public bool canSee(GameObject target)
    {
        Transform targetTF = target.GetComponent<Transform>();
        Vector3 targetPosition = targetTF.position;
        Vector3 vectorToTarget = target.transform.position - tf.position;
        //Detect if target is in FOV
        float angleToTarget = Vector3.Angle(vectorToTarget, tf.up);
        if(angleToTarget <= FieldOfView)
        {
            //Detect if in line of sight
            RaycastHit2D hitInfo = Physics2D.Raycast(tf.position, vectorToTarget);

            if (hitInfo.collider.gameObject == target)
            {
                return true;
            }
            
        }
        return false;
    }
    
    //Turning towards the player
    protected void RotateTowards(Transform target, bool isInstant)
    {//Tracking position of player
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        if (!isInstant)
        {
            Quaternion targetLocation = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, turnSpeed * Time.deltaTime);
        }
        else
        {//Editing rotation based on location
            transform.rotation = Quaternion.Euler(0, 0, zAngle);
        }
    }
}
