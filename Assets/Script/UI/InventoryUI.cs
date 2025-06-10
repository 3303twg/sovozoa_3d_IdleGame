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

    //인벤토리상단의 아이템 정보 표기용
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

        //장착버튼 활성화 및 비활성화
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
    //버튼으로 호출중
    public void HideInventory()
    {
        inventoryUI.SetActive(false);
    }


    //버튼으로 호출중
    public void EquipBtn()
    {
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(true);

        
        EventBus.Publish("UnEquipEvent", slot);
        slot.EquipItem();
        EventBus.Publish("EquipEvent", slot.itemData);
        EventBus.Publish("RefrashSlotEvent", null);
    }
    //버튼으로 호출중
    public void UnEquipBtn()
    {
        equipBtn.SetActive(true);
        unEquipBtn.SetActive(false);
        //slot.UnEquipItem();
        EventBus.Publish("UnEquipEvent", slot);
        EventBus.Publish("RefrashSlotEvent", null);



    }
}
