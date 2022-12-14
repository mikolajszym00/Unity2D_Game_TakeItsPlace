using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingGod : MonoBehaviour
// God interaction with building
{
    [SerializeField] GameObject godMode;
    [SerializeField] UpgradeMenu upgradeMenu;

    [SerializeField] GameObject buiCanvas;
    [SerializeField] GameObject buttonPanel;

    bool upgradeWindowOpened = false;

    void OnClick() // co jeśli zmienimy tryby
    {
        if (!godMode.activeSelf || upgradeWindowOpened) // można naraz kliknąć upgrade i button panel
        { return; }

        Vector3 mousePos = GetMousePos();

        foreach (Transform building in transform)
        {
            if (building.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(mousePos))
            {
                buiCanvas.SetActive(true); 
                building.gameObject.GetComponent<BuildingUpgrade>().DisplayUpgradeWindow(upgradeMenu);
                
                upgradeWindowOpened = true;
            }
        }
    }

    public void CheckUpgrades(Vector3 mousePos, Sprite sprite, GameObject elem)
    // wywołuje się, gdy gracz postawi element
    {
        if (elem.tag == "CoveredTile") { return; }

        foreach (Transform building in transform)
        {
            if (building.Find("Object Upgrade Area").gameObject.GetComponent<CircleCollider2D>().bounds.Contains(mousePos)) // czy ma być w tym tile
            {
                building.gameObject.GetComponent<BuildingUpgrade>().AddElemToCurrentLevel(sprite, elem);
            }
        }
    }

    public void OnCloseClick()
    {
        upgradeMenu.GetSuccessObj().SetActive(true);
        upgradeMenu.GetEnergyLossObj().SetActive(true);

        upgradeMenu.GetUpgradeDisplayer().DestroyIcons();

        buiCanvas.SetActive(false);
        upgradeWindowOpened = false;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos3 = Input.mousePosition;

        mousePos3 = Camera.main.ScreenToWorldPoint(mousePos3);

        return new Vector3(mousePos3.x, mousePos3.y, 0); // mysz jest tam gdzie kamera czyli na -1
    }
}
