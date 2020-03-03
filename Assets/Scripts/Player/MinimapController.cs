using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform target;
    public Vector3 posOffset;

    void Update()
    {
        transform.position = target.position + posOffset;
    } 
}
