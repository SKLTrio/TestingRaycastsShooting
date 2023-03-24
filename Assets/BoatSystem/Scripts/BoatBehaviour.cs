using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public GameObject sail;
    public BoatInteraction PlayerObject;

    public float MaxSpeed = 10f;
    public float TurnSpeed = 10f;
    public float SailAngle = 0f;
    public float WindAngle = 0f;
    public float WindSpeed = 1f;
    public float BoatSpeed = 0f;

    void Start()
    {
        InvokeRepeating("RandomWindDirection", 0f, 6f);
    }

    void Update()
    {
        if (PlayerObject.InBoat)
        {
            //Calculating the direction of the wind
            Vector3 WindDirection = Quaternion.Euler(0f, WindAngle, 0f) * Vector3.forward;

            //Calculate the angle between the sail and the wind.
            float AngleDifference = Vector3.SignedAngle(sail.transform.forward, WindDirection, Vector3.up);

            //Rotate the sail towards the wind.
            SailAngle += Mathf.Clamp(AngleDifference, -TurnSpeed * Time.deltaTime, TurnSpeed * Time.deltaTime);
            SailAngle = Mathf.Clamp(SailAngle, -90f, 90f);
            sail.transform.localRotation = Quaternion.Euler(SailAngle, 0f, 0f);

            //Calculate the boat's speed based on the angle between the boat and the wind.
            float speedScale = Mathf.Cos(Mathf.Deg2Rad * AngleDifference);
            BoatSpeed = speedScale * MaxSpeed;

            //Move the boat forward based on the wind and boat speed.
            transform.position += transform.forward * BoatSpeed * WindSpeed * Time.deltaTime;

            // Rotate the boat towards the wind
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(WindDirection), TurnSpeed * Time.deltaTime);
        }
    }

    void RandomWindDirection()
    {
        WindAngle = Random.Range(0f, 360f);
    }

}