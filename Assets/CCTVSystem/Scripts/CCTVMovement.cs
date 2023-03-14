using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVMovement : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform rotatingCameraPart;

    [SerializeField]
    float rotationSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Rotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Rotation()
    {
        var initialrotation = transform.rotation;

        
    }
}
