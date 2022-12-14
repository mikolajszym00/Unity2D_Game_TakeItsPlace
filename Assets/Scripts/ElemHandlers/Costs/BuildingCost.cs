using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingCost : ElemCost
{
    [SerializeField] GameObject inventoryObj;
    Inventory inventory;

    [SerializeField] GameObject[] components;

    void Start()
    {
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    public override bool CanBeBuilt()
    {
        foreach(GameObject comp in components)
        {
            Sprite mySprite = GetSpriteFromComp(comp);

            int quantity = inventory.GetItemQuantity(mySprite);

            if (quantity < GetPriceFromComp(comp))
            {
                return false;
            }
        }

        return true;
    }

    public override void PayForElem()
    {
        foreach (GameObject comp in components)
        {
            inventory.AddToInventory(GetSpriteFromComp(comp), -GetPriceFromComp(comp));
        }
    }

    // public GameObject[] GetMyComponents()
    // {
    //     return components;
    // }

    public Sprite GetSpriteFromComp(GameObject comp)
    {
        return comp.transform.Find("Elem").GetComponent<Image>().sprite;
    }    

    public int GetPriceFromComp(GameObject comp)
    {
        Transform stockValue = comp.transform.Find("Stock BG").Find("Stock Value");
        return int.Parse(stockValue.gameObject.GetComponent<TextMeshProUGUI>().text);
    }
}
