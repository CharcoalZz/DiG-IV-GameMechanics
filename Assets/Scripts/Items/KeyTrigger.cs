using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public Key key;

    // Start is called before the first frame update
    void Start()
    {
        key.Start(GetComponent<MeshRenderer>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            key.OnTriggerEnter(other);
            Destroy(gameObject);
        }
    }
}
