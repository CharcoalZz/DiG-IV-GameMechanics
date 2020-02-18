using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public float timer = 0;
    public bool timerEnabled = true;
    public HUD hud;

    void Update()
    {
        if(timerEnabled == true)
        {
            timer += Time.deltaTime;
            hud.UpdateTimer(timer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DisablerTimer();
        }
    }

    public void DisablerTimer()
    {
        timerEnabled = false;
    }
}
