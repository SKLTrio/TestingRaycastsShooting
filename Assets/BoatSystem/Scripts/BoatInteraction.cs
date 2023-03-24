using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{
    public BoatBehaviour Boat;
    public Transform BoatSeat;

    public float InteractionRange = 1f;

    private bool IsInRange = false;
    public bool InBoat = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (InBoat)
            {
                // Remove player from boat
                InBoat = false;
                //Activating the BoatLockBox Shapes.
                Boat.BoatLockBox.SetActive(false);

            }
            else if (IsInRange)
            {
                // Add player to boat
                InBoat = true;
                //Activating the BoatLockBox Shapes.
                Boat.BoatLockBox.SetActive(true);
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