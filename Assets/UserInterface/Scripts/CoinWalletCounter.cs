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

    // Start is called before the first frame update
    void Start()
    {
        CurrencyCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrencyCount()
    {
        GameObject thePlayer = GameObject.Find("PlayerObject");
        Item itemScript = thePlayer.GetComponent<Item>();

        if (itemScript.CoinCounter == 1)
        {
            Debug.Log("Picked up 1 gold coin");
            GoldAmount += itemScript.currencyValue;
            TextMeshProUGUI GoldText = GetComponent<TextMeshProUGUI>();
            GoldText.text = GoldAmount.ToString();
        }

        else if (itemScript.CoinCounter == 2)
        {
            Debug.Log("Picked up 1 silver coin");
            SilverAmount += itemScript.currencyValue;
            TextMeshProUGUI SilverText = GetComponent<TextMeshProUGUI>();
            SilverText.text = SilverAmount.ToString();
        }

        else if (itemScript.CoinCounter == 3)
        {
            Debug.Log("Picked up 1 bronze coin");
            BronzeAmount += itemScript.currencyValue;
            TextMeshProUGUI BronzeText = GetComponent<TextMeshProUGUI>();
            BronzeText.text = BronzeAmount.ToString();
        }
    }
}
