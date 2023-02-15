using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class RedTrap : MonoBehaviour
{

    public GameObject TrapPrefab;
    public Sprite icon;

    public string TrapName;
    [TextArea(4, 16)]
    public string description;

    [SerializeField]
    float rawDamage = 5f;

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

        healthManagerScript.Hit(rawDamage);

        Debug.Log("Took " + rawDamage + " damage");

    }


}

