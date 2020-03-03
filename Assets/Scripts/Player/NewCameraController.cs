using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderY = 200f;
    public float panBorderX = 400f;
    public Vector2 panLimit;


    void Update()
    {
        Vector3 pos = transform.localPosition;

        if(Input.GetKey(KeyCode.Mouse2) && Input.mousePosition.y >= Screen.height - panBorderY)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse2) && Input.mousePosition.y <= panBorderY)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse2) && Input.mousePosition.x >= Screen.width - panBorderX)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse2) && Input.mousePosition.x <= panBorderX)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.localPosition = pos;

    }
}
