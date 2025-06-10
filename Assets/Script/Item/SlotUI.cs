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
    public GameObject equipIcon;

    private void OnEnable()
    {
        EventBus.Subscribe("RefrashSlotEvent", UpdateUI);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe("RefrashSlotEvent", UpdateUI);
    }
    public void Bind(Slot data)
    {
        slot = data;
        UpdateUI(null);
    }


    public void UpdateUI(object obj)
    {
        if (slot == null) return;
        icon.sprite = slot.itemData.icon;
        cntText.text = slot.itemData.cnt.ToString();
        if (slot.isEquip)
        {
            equipIcon.SetActive(true);
        }
        else
        {
            equipIcon.SetActive(false);
        }
    }


    //이건 버튼으로 호출함
    public void SelectItem()
    {
        EventBus.Publish("SelectItemEvent", slot);
    }

}
