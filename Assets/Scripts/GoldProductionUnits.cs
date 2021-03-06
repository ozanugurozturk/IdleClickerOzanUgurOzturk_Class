﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnits : MonoBehaviour
{
    [System.Serializable]
    public class GoldProductionUnit
    {
        public string name = "GoldPress";
        public string buttonName = "ButtonName";
        public int productionAmount = 1;
        public int costs = 100;
        public float productionTime = 1f;        
    }

    public GoldProductionUnit[] goldProductionUnits;
    public Transform goldProductionUnitParent;
    public GameObject goldProductionUnitPrefab;

    void Start()
    {
        foreach (var productionUnit in this.goldProductionUnits)
        {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.goldProductionUnitParent);
            instance.GetComponent<GoldPress>().SetUp(productionUnit);
        }
    }



}
