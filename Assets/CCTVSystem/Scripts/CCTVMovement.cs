using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVMovement : MonoBehaviour
{
    public float Speed = 30f; //Speed of the object movement.
    public float Angle = 180f; //Angle at which the object will be moved.
    public float FOV = 120f; //Field of view in degree.
    public float Range = 12f; //The range of the camera.
    //public float Light_Blink_Speed = 1f;

    [SerializeField] Transform Player_Obj;
    [SerializeField] Transform Camera_Parts;

    [SerializeField] GameObject Green_Light;
    [SerializeField] GameObject Red_Light;

    [SerializeField] public AudioSource Alarm;

    bool ShouldRotateCamera = true;

    bool isBeeping = false;
    bool isRedLightBlinking = false;
    float timer = 0f;

    void Start()
    {
        Green_Light.SetActive(true);
        Red_Light.SetActive(false);
    }


    void Update()
    {
        if (ShouldRotateCamera)
        {
            float currentAngle = Mathf.Sin(Time.time * Speed * Mathf.Deg2Rad) * FOV / 2;
            Camera_Parts.localRotation = Quaternion.Euler(Angle, currentAngle, 0f);
        }

        if (!ShouldRotateCamera)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                if (!isRedLightBlinking)
                {
                    StartCoroutine(BlinkRed_Light());
                }
            }
        }

        else
        {
            timer = 0f;
            isRedLightBlinking = false;
        }
    }

    private IEnumerator BlinkRed_Light()
    {
        isRedLightBlinking = true;
        while (!ShouldRotateCamera)
        {
            Alarm.Play();
            Red_Light.SetActive(false);
            yield return new WaitForSecondsRealtime(1f);
            Red_Light.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
        }

        Red_Light.SetActive(false);
        isRedLightBlinking = false;
    }

    private void OnTriggerStay(Collider collider)
    {
        ShouldRotateCamera = false;
        Green_Light.SetActive(false);
        Red_Light.SetActive(true);
        Camera_Parts.transform.LookAt(Player_Obj);
    }

    private void OnTriggerExit(Collider collider)
    {
        ShouldRotateCamera = true;
        Green_Light.SetActive(true);
        Red_Light.SetActive(false);
        isRedLightBlinking = false;
        timer = 0f;

    }

}
