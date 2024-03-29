
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25;

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        AudioManager.instance.PlayAtSource("GruntMale", gameObject);
        if (hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    void SelfTerminate()
    {
        Destroy(gameObject);
    }
}