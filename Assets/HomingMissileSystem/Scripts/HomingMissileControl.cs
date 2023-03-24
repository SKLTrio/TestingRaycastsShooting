using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HomingMissileControl : MonoBehaviour
{
    public GameObject Missile;
    public GameObject PlayerObj;

    public float MissileSpeed = 10f;
    public float rawDamage = 75f;

    Vector3 origin;
    Vector3 destination;
    Vector3 directionVector;

    private void Start()
    {
        Vector3 origin = Missile.transform.position;
        Vector3 destination = PlayerObj.transform.position;
        Vector3 directionVector = destination - origin;
    }

    void Update()
    {
        origin = transform.position;
        destination = PlayerObj.transform.position;
        directionVector = destination - origin;
        transform.forward = directionVector;
        transform.position += directionVector.normalized * Time.deltaTime * MissileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerObj)
        {
            Destroy(Missile);

            GameObject thePlayer = GameObject.Find("PlayerObject");
            HealthManager healthManagerScript = thePlayer.GetComponent<HealthManager>();
            Debug.Log("You have been hit by a " + transform.name + "!");
            healthManagerScript.Hit(rawDamage);
        }
    }
}