using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "upgradePath", menuName = "upgradePathSO")]
public class UpgradePathSO : ScriptableObject
{
    [SerializeField] UpgradeSO[] upgrades; 

    public int CountLevels()
    {
        return upgrades.Length;
    }

    public UpgradeSO[] GetUpgrades()
    {
        return upgrades;
    }

    public Sprite[] GetSpritesFromCurentLevel(int index)
    {
        return upgrades[index].GetSprites();
    }

}