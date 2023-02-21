
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 100f;
    public float minHitPoints = 0f;

    public Slider healthSlider;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    private void Update()
    {
        
    }

    public void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        SetHealthSlider();

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <= 0)
        {
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }

    void SetHealthSlider()
    {
        if (healthSlider != null)
        {
           healthSlider.value = NormalisedHitPoints();
        }
    }

    public float NormalisedHitPoints()
    {
        return hitPoints / maxHitPoints;

    }

    public void HealthKitAdd(float GiveHealth)
    {
        hitPoints += GiveHealth;
        hitPoints = Mathf.Min(hitPoints, maxHitPoints); // This line of code makes sure that the player's health cannot go above the 100 the 'maxHitPoints' variable, which is set to 100.
        Debug.Log("Added " + GiveHealth + " to the player's health");
        Debug.Log("Player's health is now: " + hitPoints);
        SetHealthSlider();  //Calling SetHealthSlider to update the slider's value.
    }

}
