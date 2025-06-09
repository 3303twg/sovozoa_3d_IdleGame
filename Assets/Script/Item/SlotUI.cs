using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI cntText;
    public Slot slot;

    public void Bind(Slot data)
    {
        slot = data;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (slot == null) return;
        icon.sprite = slot.itemData.icon;
        cntText.text = slot.itemData.cnt.ToString();
    }


    //이건 버튼으로 호출함
    public void SelectItem()
    {
        EventBus.Publish("SelectItemEvent", slot);
    }

}
