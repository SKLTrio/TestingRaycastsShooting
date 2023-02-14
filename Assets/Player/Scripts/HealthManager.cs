
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 100f;

    public Slider healthSlider;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void Hit(float rawDamage)
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
        GameObject healthKitObj = GameObject.Find("HealthKit");

        HealthKit healthKitScript = healthKitObj.GetComponent<HealthKit>();



        //healthKitScript.GiveHealth = 

        //if ()
        //{

        //}

        return hitPoints / maxHitPoints;
    }

}
