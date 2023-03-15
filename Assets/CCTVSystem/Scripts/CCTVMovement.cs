using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVMovement : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float minRotation = -30f;
    [SerializeField] private float maxRotation = 30f;

    private float currentRotation = 0f;
    private float direction = 1f;

    private void Start()
    {
        transforms = new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            transforms[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        foreach (Transform childTransform in transforms)
        {
            // Rotate the transform horizontally
            childTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * direction);
            currentRotation += rotationSpeed * Time.deltaTime * direction;
            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);
            childTransform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);

            // Change direction if we reach min/max rotation
            if (currentRotation >= maxRotation || currentRotation <= minRotation)
            {
                direction *= -1f;
            }
        }
    }
}