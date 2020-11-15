using System;
using UnityEngine;
using UnityEngine.UI;
using static GoldProductionUnits;

public class GoldPress : MonoBehaviour
{
    GoldProductionUnit goldProductionUnit;
    public Text goldPressAmountText;
    public Text goldPressButtonText;
    float elapsedTime;

    public void SetUp(GoldProductionUnit goldProductionUnit)
    {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
    }

    public int GoldPressAmount
    {
        get=> PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
        set
        {
            PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
            UpdateGoldPressAmountLabel();
        }
    }
    void UpdateGoldPressAmountLabel()
    {
        this.goldPressAmountText.text = this.GoldPressAmount.ToString($"0 {this.goldProductionUnit.name}");
        this.goldPressButtonText.text = $"{this.goldProductionUnit.name} (cost:{this.goldProductionUnit.costs})";
    }
    private void Start()
    {
        UpdateGoldPressAmountLabel();
    }
    private void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime>=this.goldProductionUnit.productionTime)
        {
            ProduceGold();
            this.elapsedTime -= this.goldProductionUnit.productionTime;
        }
    }
    private void ProduceGold()
    {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.goldProductionUnit.productionAmount * this.GoldPressAmount; 
    }
    public void BuyGoldPress()
    {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount>=this.goldProductionUnit.costs)
        {
            gold.GoldAmount -= this.goldProductionUnit.costs;
            this.GoldPressAmount += 1;
        }
    } 

}
