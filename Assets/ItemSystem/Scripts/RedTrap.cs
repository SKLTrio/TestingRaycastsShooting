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

    public float timeBetweenHits = 0.5f;

    public float timeSinceLastHit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerStay(Collider collider)
    {
        timeSinceLastHit += Time.deltaTime;

        if (timeSinceLastHit >= timeBetweenHits)
        {
            timeSinceLastHit = 0f;
            TakeDamage();
        }

    }

    public void TakeDamage()
    {
        GameObject thePlayer = GameObject.Find("PlayerObject");
        HealthManager healthManagerScript = thePlayer.GetComponent<HealthManager>();
        healthManagerScript.hitPoints -= trapDamage;

        Debug.Log("Took " + trapDamage + " damage");

        Debug.Log("OUCH: " + healthManagerScript.hitPoints.ToString());

        if (healthManagerScript.hitPoints <= 0)
        {
            Debug.Log("GAME OVER: " + healthManagerScript.hitPoints.ToString());
        }

    }


}

