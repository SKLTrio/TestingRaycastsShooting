using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class RedTrap : MonoBehaviour
{

    public GameObject TrapPrefab;
    public Sprite icon;

    public string TrapName;
    [TextArea(4, 16)]
    public string description;

    [SerializeField]
    float trapDamage = 5f;

    [SerializeField]
    public bool isConsumable = false; //If true, item will be destroyed (or quantity reduced) when used

    [SerializeField]
    bool isPickupOnCollision = false; //If this is true, instead of pressing 'F' to interact, you can walk through the item to pick up.

    public float damageTimeCounter = 1f; //Timer for how long each time the red lava trap takes damage off the player's health.

    private float time = 0f;



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
        InvokeRepeating("Interact", 1f, 1f);  //1s delay, repeat every 1s
        GameObject thePlayer = GameObject.Find("PlayerObject");
        HealthManager healthManagerScript = thePlayer.GetComponent<HealthManager>();
        healthManagerScript.hitPoints -= trapDamage;

        Debug.Log("You have entered the " + transform.name);

        if (isConsumable)
        {
            time = 0.0f;

            Debug.Log("OUCH: " + healthManagerScript.hitPoints.ToString());
            Destroy(gameObject);

            if (healthManagerScript.hitPoints <= 0)
            {
                Debug.Log("GAME OVER: " + healthManagerScript.hitPoints.ToString());
            }

        }
        
    }

}

