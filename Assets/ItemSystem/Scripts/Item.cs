using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Item : MonoBehaviour
{
    public GameObject itemPrefab;
    public Sprite icon;

    public string itemName;
    [TextArea(4, 16)]
    public string description;

    [SerializeField]
    public float currencyValue;

    [SerializeField]
    public float weight = 0;
    [SerializeField]
    public int quantity = 1;
    [SerializeField]
    public int maxstackableQuantity = 1; //For bundles of items, such as arrows or coins.

    [SerializeField]
    public bool isStorable = false; //If false, item will be used when picked up.
    [SerializeField]
    public bool isConsumable = false; //If true, item will be destroyed (or quantity reduced) when used

    [SerializeField]
    bool isPickupOnCollision = false; // If this is true, instead of pressing 'F' to interact, you can walk through the item to pick up.

    //Start is called before the first frame update
    void Start()
    {
        if (isPickupOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
                Interact();
            }
        }
    }

    public void Interact()
    {

        Debug.Log("Picked up " + transform.name);

        if (isStorable)
        {
            Store();
        }

        else
        {
            Use();
        }

    }

    void Store()
    {
        Debug.Log("Storing " + transform.name);

        //Need to do.

        Destroy(gameObject);

    }

    void Use()
    {
        if (transform != null)
        {

            GameObject thePlayer = GameObject.Find("PlayerObject");
        CoinWallet walletScript = thePlayer.GetComponent<CoinWallet>();
        GameObject theCoinCounter = GameObject.Find("CoinCounter");
        CoinWalletCounter coinCounterScript = theCoinCounter.GetComponent<CoinWalletCounter>();

        Debug.Log("Using " + transform.name);

            if (transform != null)
            {

                quantity--;
                if (quantity <= 0)
                {
                    Destroy(gameObject);

                    if (transform.name == "BronzeCoin")
                    {
                        currencyValue += 25f;
                        Debug.Log("Added " + currencyValue + " to Your wallet");
                        walletScript.Wallet += currencyValue;
                        Debug.Log("Your Balance is: " + walletScript.Wallet + " Units!");
                        coinCounterScript.CurrencyCount();

                    }

                    else if (transform.name == "SilverCoin")
                    {
                        currencyValue += 50f;
                        Debug.Log("Added " + currencyValue + " to Your wallet");
                        walletScript.Wallet += currencyValue;
                        Debug.Log("Your Balance is: " + walletScript.Wallet + " Units!");
                        coinCounterScript.CurrencyCount();
                    }

                    else if (transform.name == "GoldCoin")
                    {
                        currencyValue += 100f;
                        Debug.Log("Added " + currencyValue + " to Your wallet");
                        walletScript.Wallet += currencyValue;
                        Debug.Log("Your Balance is: " + walletScript.Wallet + " Units!");
                        coinCounterScript.CurrencyCount();
                    }

                    else
                    {
                        currencyValue = 0f;
                        Debug.Log("Added " + currencyValue + " to Your wallet");
                        walletScript.Wallet += currencyValue;
                        Debug.Log("Your Balance is: " + walletScript.Wallet + " Units!");
                    }

                }
            }
        }
    }
}
