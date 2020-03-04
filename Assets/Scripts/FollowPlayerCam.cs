using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{//Getting following position
    private Func<Vector3> GetCameraFollowPointFunc;
    //Camera set up
    public void Setup(Func<Vector3> GetCameraFollowPointFunc)
    {
        this.GetCameraFollowPointFunc = GetCameraFollowPointFunc;
    }
    void Update()
    {//Following player
        Vector3 cameraFollowPos = GetCameraFollowPointFunc();
        cameraFollowPos.z = transform.position.z;
        transform.position = cameraFollowPos;
    }

}
