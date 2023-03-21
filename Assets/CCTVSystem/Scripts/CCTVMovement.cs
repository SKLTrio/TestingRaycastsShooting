using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UIElements;

public class CCTVMovement : MonoBehaviour
{
    public float speed = 1f; // speed of the object movement
    public float angle = 75f; // angle at which the object will be moved
    public float lightAngle = 150f; // angle at which the object will be moved
    public float fov = 60f; // field of view in degree
    public float range = 12f; // the range of the camera.

    public Transform target; // target to look at (optional)

    public Transform CameraPart1;
    //public Transform CameraPart2;
    //public Transform CameraLightModel1;
    //public Transform CameraLightModel2;
    //public Transform CameraLight;

    void Start()
    {

    }

    void Update()
    {
        // calculate the current angle of the object based on time and speed
        float currentAngle = Mathf.Sin(Time.time * speed * Mathf.Deg2Rad) * 30f;

        // set the rotation of the child objects.
        CameraPart1.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        //CameraPart2.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        //CameraLightModel1.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        //CameraLightModel2.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        //CameraLight.localRotation = Quaternion.Euler(lightAngle, currentAngle, 0f);

        //CameraPart1.transform.LookAt(target.position, angle);

    }

    

    //private void onTriggerStay(Collider collider)
    //{
       // Debug.Log("CCTV Camera Range: " + collider.name);

        //if (collider.tag == "Player")
        //{
            //Vector3 directionVector = (collider.transform.position - CameraPart1.position);

        //}

    //}


}