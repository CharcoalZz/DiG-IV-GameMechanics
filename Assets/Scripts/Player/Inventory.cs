using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size;
    public int currentSize;
    public List<Item> items;
    
    public void AddItem(Item i)
    {
        if(size > currentSize)
        {
            if(i.GetType() == typeof(Key))
            {
                Item t = i.CloneItem();
                items.Add(t);
                currentSize++;
            }
        }
    }
}
