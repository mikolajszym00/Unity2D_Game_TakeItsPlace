using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProduction : BuildingFeature
{
    [SerializeField] public Sprite[] components;
    [SerializeField] public int[] componentsQuantities;
    [SerializeField] public Sprite[] products;

    [SerializeField] public int baseSuccess;
    [SerializeField] public int baseEnergyCost;
}
