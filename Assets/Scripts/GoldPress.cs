using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldPress : MonoBehaviour
{
    public int productionAmount = 1;
    public int costs = 100;
    public float productionTime = 1f;
    public Text goldPressAmountText;
    float elapsedTime;
    public int GoldPressAmount
    {
        get=> PlayerPrefs.GetInt("GoldPress",0);
        set
        {
            PlayerPrefs.SetInt("GoldPress", value);
            UpdateGoldPressAmountLabel();
        }
    }
    void UpdateGoldPressAmountLabel()
    {
        this.goldPressAmountText.text = this.GoldPressAmount.ToString("0 GoldPresses");
    }
    private void Start()
    {
        UpdateGoldPressAmountLabel();
    }
    private void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime>=this.productionTime)
        {
            ProduceGold();
            this.elapsedTime -= this.productionTime;
        }
    }
    private void ProduceGold()
    {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.productionAmount * this.GoldPressAmount; 
    }
    public void BuyGoldPress()
    {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount>=this.costs)
        {
            gold.GoldAmount -= this.costs;
            this.GoldPressAmount += 1;
        }
    } 

}
