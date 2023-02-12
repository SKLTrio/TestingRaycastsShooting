using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    public GameObject HealthPrefab;
    public Sprite icon;

    public string HealthItemName;
    [TextArea(4, 16)]
    public string description;

    [SerializeField]
    float GiveHealth = 25f;

    [SerializeField]
    public bool isConsumable = false; //If true, item will be destroyed (or quantity reduced) when used

    [SerializeField]
    bool isPickupOnCollision = false; // If this is true, instead of pressing 'F' to interact, you can walk through the item to pick up.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        GameObject thePlayer = GameObject.Find("PlayerObject");
        HealthManager healthManagerScript = thePlayer.GetComponent<HealthManager>();

        Debug.Log("You have aquired a " + transform.name);
        healthManagerScript.hitPoints += GiveHealth;
        Debug.Log("Player Health = " + healthManagerScript.hitPoints.ToString());

        if (isConsumable)
        {
            Destroy(gameObject);
        }

    }

}
