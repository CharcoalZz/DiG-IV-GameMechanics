using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Key : Item
{
    public enum KeyColour
    {
        Red, Green, Blue
    }
    public KeyColour colour;
    public Color c;

    // Start is called before the first frame update
    public override void Start(MeshRenderer renderer)
    {
        renderer.material.color = c;
    }

    public override void PickUpItem(Inventory inventory)
    {
        if(inventory.currentSize < inventory.size)
        {
            inventory.AddItem(CloneItem());
        }
    }

    public override Item CloneItem()
    {
        Key newInstance = new Key
        {
            colour = colour,
            c = c
        };
        return newInstance;
    }
}
