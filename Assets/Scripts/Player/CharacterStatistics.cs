using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatistics : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float currentScore = 0;

    private PlayerController pController;
    private CharacterController charController;
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        pController = GetComponent<PlayerController>();
        charController = GetComponent<CharacterController>();
        hud = GetComponent<HUD>();
        currentHealth = maxHealth;
        hud.UpdateHealth(this);
        hud.UpdateScore(this);

    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hud.UpdateHealth(this);
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    public void HealHealth(float heal)
    {
        if (currentHealth >= 100f)
        {
            Debug.Log("You are full health!");
        }
        else
        {
            currentHealth += heal;
            hud.UpdateHealth(this);
        }
    }


    public void Death()
    {
        Debug.Log("Player has died.");
        GetComponent<MeshRenderer>().enabled = false;
        pController.enabled = false;
        charController.enabled = false;
    }

    public void AddScore(float scoreValue)
    {
        currentScore += scoreValue;
        hud.UpdateScore(this);
    }
}
