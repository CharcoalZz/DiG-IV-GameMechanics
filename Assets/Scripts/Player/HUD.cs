using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Image healthBarImg;
    public Text healthText;
    public Text timerText;
    public Text scoreText;

    // Update is called once per frame
    public void UpdateHealth(CharacterStatistics stats)
    {
        healthText.text = stats.currentHealth + "/" + stats.maxHealth;
        healthBarImg.fillAmount = stats.currentHealth / stats.maxHealth;
    }

    public void UpdateScore(CharacterStatistics stats)
    {
        scoreText.text = "Score: " + stats.currentScore;
    }

    public void UpdateTimer(float time)
    {
        timerText.text = "Time: " + FormatFloatAsTime(time);
    }

    public string FormatFloatAsTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string timeTag = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeTag;
    }
}
