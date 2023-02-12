using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Trap : MonoBehaviour
{

    public GameObject TrapPrefab;
    public Sprite icon;

    public string TrapName;
    [TextArea(4, 16)]
    public string description;

    [SerializeField]
    float trapDamage = 50f;

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
        healthManagerScript.hitPoints -= trapDamage;

        Debug.Log("You have entered the " + transform.name);

        if (isConsumable)
        {

            Debug.Log("OUCH: " + healthManagerScript.hitPoints.ToString());
            Destroy(gameObject);

            if (healthManagerScript.hitPoints <= 0)
            {
                Debug.Log("GAME OVER: " + healthManagerScript.hitPoints.ToString());
            }
        }

    }

}
