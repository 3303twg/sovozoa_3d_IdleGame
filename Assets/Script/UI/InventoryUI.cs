using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryUI;
    public Image infoIcon;
    //������ �����͸� ǥ������ �ؽ�Ʈ��
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI criticalChanceText;
    public TextMeshProUGUI criticalRatioText;
    public TextMeshProUGUI accuracyText;

    public GameObject equipBtn;
    public GameObject unEquipBtn;

    public GameObject sellBtn;
    Slot slot;
    private void OnEnable()
    {
        inventory = GetComponent<Inventory>();
        EventBus.Subscribe("SelectItemEvent", RefrashItemData);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("SelectItemEvent", RefrashItemData);
    }

    //�κ��丮����� ������ ���� ǥ���
    public void RefrashItemData(object obj)
    {
        if (obj != null)
        {
            slot = (Slot)obj;
            ItemData data = slot.itemData;
            infoIcon.sprite = data.icon;
            nameText.text = data.itemName.ToString();
            infoText.text = data.itemInfo.ToString();
            powerText.text = "Power : " + data.attackPower.ToString();
            attackSpeedText.text = "Speed : " + data.attackSpeed.ToString();
            criticalChanceText.text = "CriticalChance : " + data.criticalChance.ToString();
            criticalRatioText.text = "CriticalRation : " + data.criticalRatio.ToString();
            accuracyText.text = "Accuracy : " + data.accuracy.ToString();

            //������ư Ȱ��ȭ �� ��Ȱ��ȭ
            if (slot.isEquip == true)
            {
                equipBtn.SetActive(false);
                unEquipBtn.SetActive(true);
            }
            else
            {
                equipBtn.SetActive(true);
                unEquipBtn.SetActive(false);
            }
        }

        else
        {
            infoIcon.sprite = null;
            nameText.text = "";
            infoText.text = "";
            powerText.text = "Power : ";
            attackSpeedText.text = "Speed : ";
            criticalChanceText.text = "CriticalChance : ";
            criticalRatioText.text = "CriticalRation : ";
            accuracyText.text = "Accuracy : ";
        }
    }


    //��ư���� ȣ����
    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
    }
    //��ư���� ȣ����
    public void HideInventory()
    {
        inventoryUI.SetActive(false);
    }


    //��ư���� ȣ����
    public void EquipBtn()
    {
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(true);

        
        EventBus.Publish("UnEquipEvent", slot);
        slot.EquipItem();
        EventBus.Publish("EquipEvent", slot.itemData);
        EventBus.Publish("RefrashSlotEvent", null);
    }
    //��ư���� ȣ����
    public void UnEquipBtn()
    {
        equipBtn.SetActive(true);
        unEquipBtn.SetActive(false);
        //slot.UnEquipItem();
        EventBus.Publish("UnEquipEvent", slot);
        EventBus.Publish("RefrashSlotEvent", null);
    }

    public void SellBtn()
    {
        if (slot != null)
        {
            if (slot.isEquip)
            {
                EventBus.Publish("UnEquipEvent", slot);
            }

            EventBus.Publish("RemoveItemEvent", slot);
            EventBus.Publish("AddGoldEvent", slot.itemData.goldValue);
            EventBus.Publish("RefrashSlotEvent", null);
            if(slot.itemData.cnt < 0)
            {
                slot = null;
                RefrashItemData(null);
                inventory.RefrashUI();
            }
        }
    }
}
