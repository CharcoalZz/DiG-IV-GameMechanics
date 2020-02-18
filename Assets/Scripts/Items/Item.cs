using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    public virtual void Start(MeshRenderer renderer)
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        PickUpItem(other.GetComponent<Inventory>());
    }

    public virtual void PickUpItem(Inventory inventory)
    {
        inventory.AddItem(this);
    }

    public virtual Item CloneItem()
    {
        return null;
    }
}
