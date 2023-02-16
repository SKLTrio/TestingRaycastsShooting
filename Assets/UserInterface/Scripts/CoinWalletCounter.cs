using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinWalletCounter : MonoBehaviour
{
    [SerializeField]
    public float GoldAmount;

    [SerializeField]
    public float SilverAmount;

    [SerializeField]
    public float BronzeAmount;

    [SerializeField]
    private TextMeshProUGUI GoldText;

    [SerializeField]
    private TextMeshProUGUI SilverText;

    [SerializeField]
    private TextMeshProUGUI BronzeText;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrencyCount()
    {
        Debug.Log("THIS HAS RUUUUUUN");

        GameObject thePlayer = GameObject.Find("PlayerObject");
        Debug.Log(thePlayer);

        Item itemScript = thePlayer.GetComponent<Item>();

        if (itemScript.transform.name == "GoldCoin")
        {
            Debug.Log("Picked up 1 gold coin");
            GoldAmount += itemScript.currencyValue;
            GoldText = GetComponentInChildren<TextMeshProUGUI>(true);

            if (GoldText != null)
            {
                GoldText.text = GoldAmount.ToString();
            }
        }

        else if (itemScript.transform.name == "SilverCoin")
        {
            Debug.Log("Picked up 1 silver coin");
            SilverAmount += itemScript.currencyValue;
            SilverText = GetComponentInChildren<TextMeshProUGUI>(true);

            if (SilverText != null)
            {
                SilverText.text = SilverAmount.ToString();
            }

            
        }

        else if (itemScript.transform.name == "BronzeCoin")
        {
            Debug.Log(itemScript.transform.name == "BronzeCoin");
            Debug.Log("Picked up 1 bronze coin");
            BronzeAmount += itemScript.currencyValue;
            BronzeText = GetComponentInChildren<TextMeshProUGUI>(true);

            if (BronzeText != null)
            {
                BronzeText.text = BronzeAmount.ToString();
            }
        }
    }
}
