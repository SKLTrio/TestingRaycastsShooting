using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CCTVMovement : MonoBehaviour
{
    public float speed = 1f; // speed of the object movement
    public float angle = 75f; // angle at which the object will be moved
    public float lightAngle = 150f; // angle at which the object will be moved
    public float fov = 60f; // field of view in degrees

    public Transform target; // target to look at (optional)

    public Transform CameraPart1;
    public Transform CameraPart2;
    public Transform CameraPart4;
    public Transform CameraPart5;
    public Transform CameraLight;

    void Start()
    {

    }

    void Update()
    {
        // calculate the current angle of the object based on time and speed
        float currentAngle = Mathf.Sin(Time.time * speed * Mathf.Deg2Rad) * 30f;
        float currentAngle2 = Mathf.Sin(Time.time * speed * Mathf.Deg2Rad) * 321f;
        //float currentAngle2 = Mathf.Sin(Time.time * speed * Mathf.Deg2Rad) * 35f;

        // set the rotation of the child objects.
        CameraPart1.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        CameraPart2.localRotation = Quaternion.Euler(angle, currentAngle2, 0f);
        CameraPart4.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        CameraPart5.localRotation = Quaternion.Euler(angle, currentAngle, 0f);
        CameraLight.localRotation = Quaternion.Euler(lightAngle, currentAngle, 0f);
    }
}