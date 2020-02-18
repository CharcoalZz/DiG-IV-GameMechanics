﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool lookAtTarget;
    public bool localPosition;
    public Transform target;
    public Vector3 rotationLock;
    public Vector3 posOffset;


    // Update is called once per frame
    void Update()
    {
        if(localPosition == true)
        {
            transform.position = target.position + posOffset;
        }

        if(lookAtTarget == true)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.eulerAngles = rotationLock;
        }
    }
}
