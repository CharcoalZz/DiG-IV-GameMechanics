using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            DetectInteraction();
        }
    }

    void DetectInteraction()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interaction")))
        {
            if(hit.collider.tag == "Door")
            {
                hit.collider.GetComponent<Door>().Activate(inventory);
            }
        }
    }
}
