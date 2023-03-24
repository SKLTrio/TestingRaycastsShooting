using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    public BoatBehaviour Boat;
    public GameObject BoatSeat;

    public float InteractionRange = 1f;

    private bool IsInRange = false;
    public bool InBoat = false;
    private Vector3 playerOffset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (InBoat)
            {
                // Remove player from boat
                InBoat = false;
                transform.SetParent(null);
            }
            else if (IsInRange)
            {
                // Add player to boat
                InBoat = true;
                transform.SetParent(BoatSeat.transform);
                transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Boat.gameObject && Vector3.Distance(transform.position, BoatSeat.transform.position) <= InteractionRange)
        {
            IsInRange = true;
        }
        else
        {
            IsInRange = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsInRange = false;
    }
}