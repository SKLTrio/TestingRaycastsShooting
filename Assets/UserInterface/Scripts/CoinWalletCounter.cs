using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class CoinWalletCounter : MonoBehaviour
{
    [SerializeField]
    public float GoldAmount;

    [SerializeField]
    public float SilverAmount;

    [SerializeField]
    public float BronzeAmount;

    [SerializeField]
    public TextMeshProUGUI GoldText;

    [SerializeField]
    public TextMeshProUGUI SilverText;

    [SerializeField]
    public TextMeshProUGUI BronzeText;

    [HideInInspector]
    private GameObject gCoin;
    private GameObject sCoin;
    private GameObject bCoin;



    // Start is called before the first frame update
    void Start()
    {

        gCoin = GameObject.Find("GoldCoin");
        sCoin = GameObject.Find("SilverCoin");
        bCoin = GameObject.Find("BronzeCoin");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrencyCount()
    {
        Item gCoinScript = gCoin.GetComponent<Item>();
        Item sCoinScript = sCoin.GetComponent<Item>();
        Item bCoinScript = bCoin.GetComponent<Item>();

        GameObject thePlayer = GameObject.Find("PlayerObject");

        if (gCoinScript.Type == CoinType.Gold)
        {
            Debug.Log("Picked up 1 gold coin");
            GoldAmount += gCoinScript.CoinCount;
            GoldText = GameObject.Find("TotalGoldCoinCounter").GetComponent<TextMeshProUGUI>();
            GoldText.text = GoldAmount.ToString();
        }

        else if (sCoinScript.Type == CoinType.Silver)
        {
            Debug.Log("Picked up 1 silver coin");
            SilverAmount += sCoinScript.CoinCount;
            SilverText = GameObject.Find("TotalSilverCoinCounter").GetComponent<TextMeshProUGUI>();
            SilverText.text = SilverAmount.ToString();
            
        }

        else if (bCoinScript.Type == CoinType.Bronze)
        {
            Debug.Log("Picked up 1 bronze coin");
            BronzeAmount += bCoinScript.CoinCount;
            BronzeText = GameObject.Find("TotalBronzeCoinCounter").GetComponent<TextMeshProUGUI>();
            BronzeText.text = BronzeAmount.ToString();
        }
    }
}
