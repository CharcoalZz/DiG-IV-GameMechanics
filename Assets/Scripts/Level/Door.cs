using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked = false;
    public Key.KeyColour key;

    public void Activate(Inventory inventory)
    {
        if(locked == true)
        {
            foreach(Key k in inventory.items)
            {
                if(k.colour == key)
                {
                    OpenDoor();
                    break;
                }
            }
        }
        else
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
