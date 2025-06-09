using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryUI.SetActive(false);
    }
}
