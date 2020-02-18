using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{

    public enum HealType
    {
        Instant
    }

    public HealType healerType;
    public float heal;
    public float coolDown;
    public bool respawn;
    public bool triggered = false;

    private void OnTriggerStay(Collider other)
    {
        if (triggered == false)
        {
            if (other.tag == "Player")
            {
                TriggerHeal(other.gameObject);
            }
        }
    }

    public void TriggerHeal(GameObject go)
    {
        if (healerType == HealType.Instant)
        {
            go.GetComponent<CharacterStatistics>().HealHealth(heal);
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        triggered = true;
        yield return new WaitForSeconds(coolDown);
        if(respawn == true)
        {
            triggered = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
