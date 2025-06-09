using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();


    //이벤트버스로 주고받을까?
    private void OnEnable()
    {
        EventBus.Subscribe("AddItemEvent", AddItem);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("AddItemEvent", AddItem);
    }

    //So로 줄필요 없을듯?
    public void AddItem(object obj)
    {
        ItemData itemData = obj as ItemData;
        //ItemData itemData = new ItemData(itemDataSo);
        if (itemData.isStackable == true)
        {
            Slot slot = slots.Find(s => s.itemData == itemData);
            if (slot != null)
            {   //일단 최대치 체크 안해줌
                slot.itemData.cnt++;
                return;
            }
        }
        slots.Add(new Slot(itemData));
    }

    public void RemoveItem(ItemData itemData)
    {
        Slot slot = slots.Find(s => s.itemData == itemData);
        if (slot != null)
        {
            slot.itemData.cnt--;
            if (slot.itemData.cnt <= 0)
            {
                slots.Remove(slot);
            }
        }
    }

    //일단은 전체 갱신
    public void RefrashUI()
    {
        foreach(Slot slot in slots)
        {
            slot.cntText.text = slot.itemData.cnt.ToString();
            slot.icon.sprite = slot.itemData.icon;
        }
    }

    public void EquipItem()
    {

    }
    public void UnEquipItem()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
