using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject checkPopUp;
    public GameObject resultPopUp;
    public TextMeshProUGUI checkPopUpText;
    public TextMeshProUGUI resultPopUpText;

    public Inventory inventory;
    public InventoryUI inventoryUI;
    public Slot slot;

    private void OnEnable()
    {
        inventory = GetComponent<Inventory>();
        inventoryUI = GetComponent<InventoryUI>();
    }

    private void OnDisable()
    {
        
    }


    //�Ʒ� �� ��ư ȣ��
    public void ShowCheckPopUp()
    {
        if (inventoryUI.slot != null)
        {
            checkPopUpText.text = "U Want Upgrade?  Use 2000G ";
            checkPopUp.SetActive(true);
        }
    }

    public void HideCheckPopUp()
    {
        checkPopUp.SetActive(false);
    }

    //���׷��̵� ��ư ����
    public void Upgrade()
    {
        HideCheckPopUp();
        inventoryUI.UnEquipBtn();
        int temp = Random.Range(0, 100);
        if(temp > 50)
        {
            slot = inventoryUI.slot;
            slot.itemData.attackPower += slot.itemData.attackPower / Random.Range(1, 20);
            slot.itemData.attackSpeed += slot.itemData.attackSpeed / Random.Range(1, 20);
            slot.itemData.criticalChance += Random.Range(-5, 5);
            slot.itemData.criticalRatio += Random.Range(-5, 5);

            resultPopUpText.text = "Succeses";
            if (slot.isEquip)
            {
                inventoryUI.EquipBtn();
                
            }
            inventoryUI.RefrashItemData(slot);


        }
        else
        {
            inventoryUI.RefrashItemData(null);
            inventory.RemoveItem(slot);
            resultPopUpText.text = "Fail";
        }
        
        inventory.RefrashUI();
        
        ShowResultPopUp();
    }

    public void ShowResultPopUp()
    {
        //checkPopUpText.text = "U Want Upgrade?  Use 2000G ";
        resultPopUp.SetActive(true);
    }

    public void HideResultPopUp()
    {
        resultPopUp.SetActive(false);
    }

    
}
