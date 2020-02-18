using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public bool rotationEnbaled = true;
    public float rotationSpeed;
    public float gravity;
    public float jumpForce;
    public Transform groundedCheckObj;
    public float checkRadius;


    private float currentSpeed;
    private float velocity;
    private bool isGrounded;
    private CharacterController controller;

    
    
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = movementSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundedCheckObj.position, checkRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        Vector3 move = Vector3.zero;
        float v = Input.GetAxis("Vertical") * currentSpeed;
        float h = Input.GetAxis("Horizontal") * currentSpeed;
        float r = Input.GetAxis("Rotate") * rotationSpeed;

        if(isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }

        ApplyMovement(move, velocity, v, h, r);
    }
        
    void ApplyMovement(Vector3 position, float velocity, float vertical, float horizontal, float angle)
    {
        if(rotationEnbaled == true)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y += angle * Time.deltaTime;
            transform.eulerAngles = rot;
        }

        position += transform.forward * vertical * currentSpeed * Time.deltaTime;
        position += transform.right * horizontal * currentSpeed * Time.deltaTime;
        position.y += velocity * Time.deltaTime;
        controller.Move(position);
    }

    private void OnDrawGizmos()
    {
        Color color = Color.magenta;
        Gizmos.color = color;
        Gizmos.DrawSphere(groundedCheckObj.position, checkRadius);
    }
}

