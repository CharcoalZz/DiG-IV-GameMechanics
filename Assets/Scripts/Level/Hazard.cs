using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public enum DamageType
    {
        Instant
    }

    public DamageType hazardType;
    public float damage;
    public float coolDown;
    public bool respawn;
    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            if(other.tag == "Player")
            {
                TriggerHazard(other.gameObject);
            }
        }
    }

    public void TriggerHazard(GameObject go)
    {
        if(hazardType == DamageType.Instant)
        {
            go.GetComponent<CharacterStatistics>().TakeDamage(damage);
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        triggered = true;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(coolDown);
        if(respawn == true)
        {
            GetComponent<MeshRenderer>().enabled = true;
            triggered = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
