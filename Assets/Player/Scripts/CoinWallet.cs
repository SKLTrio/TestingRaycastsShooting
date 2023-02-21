using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    public float Wallet;



    [SerializeField]
    public TextMeshProUGUI unitValueText;

    // Start is called before the first frame update
    void Start()
    {
        unitValueText = GameObject.Find("CoinsUnitCountText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnitsToTextMesh()
    {
        unitValueText.text = Wallet.ToString() + " Units";
    }

}
