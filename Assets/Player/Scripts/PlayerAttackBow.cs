using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBow : MonoBehaviour
{
    public GameObject Arrow;

    Transform cameraTransform;
    //float range = 100f;

    [SerializeField]
    float rawDamage = 10f;

    public float pullStartTime = 0.0f;
    public float ArrowSpeed = 100.0f;
    public float nextFire = 0.0f;
    public float pullTime = 1f;
    public float maxStrengthPullTime = 1.5f;
    public bool falsePull = false;

    void Update()
    {
        FireBow();
    }

    void FireBow()
    {
        //Pulling back the bow (Invisible anyway).
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > nextFire)
            {
                cameraTransform = Camera.main.transform;
                pullStartTime = Time.time;
            }

            else
            {
                falsePull = true;
            }

            //Actually shooting the arrow.
        if (Input.GetButtonUp("Fire1"))
        {
            if (!falsePull)
                {
                    nextFire = Time.time + pullTime;

                    var timePulledBack = Time.time - pullStartTime; // this is how long the button was held
                    if (timePulledBack > maxStrengthPullTime)
                    {
                        // this says max strength is reached
                        timePulledBack = maxStrengthPullTime; // max strength is ArrowSpeed * maxStrengthPullTime
                        var arrowSpeed = ArrowSpeed * timePulledBack;
                    }

                    Arrow = Instantiate(Arrow,GameObject.Find("Arrow").transform.position, transform.rotation);

                    Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * ArrowSpeed); // adjusted speed

                    GameObject Bow = GameObject.Instantiate(Arrow, transform.position, transform.rotation);
                    Bow.GetComponent<Rigidbody>().AddForce(transform.forward * rawDamage);

                    GameObject Shot = GameObject.Instantiate(Arrow, transform.position, transform.rotation);

                    Shot.GetComponent<Rigidbody>().AddForce(transform.forward * rawDamage);

                }

            }
        }

        else
        {
            falsePull = false;
        }
            

    }
}