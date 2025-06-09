using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public Image infoIcon;
    //아이템 데이터만 표기해줄 텍스트들
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
        EventBus.Subscribe("SelectItemEvent", RefrashItemData);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("SelectItemEvent", RefrashItemData);
    }

    public void RefrashItemData(object obj)
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


    //버튼으로 호출중
    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryUI.SetActive(false);
    }

    public void EquipBtn()
    {
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(true);

        slot.EquipItem();
        EventBus.Publish("UnEquipEvent", slot);
        EventBus.Publish("EquipEvent", slot.itemData);
    }
}
