using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();


    //�̺�Ʈ������ �ְ������?
    private void OnEnable()
    {
        EventBus.Subscribe("AddItemEvent", AddItem);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("AddItemEvent", AddItem);
    }

    //So�� ���ʿ� ������?
    public void AddItem(object obj)
    {
        ItemData itemData = obj as ItemData;
        //ItemData itemData = new ItemData(itemDataSo);
        if (itemData.isStackable == true)
        {
            Slot slot = slots.Find(s => s.itemData == itemData);
            if (slot != null)
            {   //�ϴ� �ִ�ġ üũ ������
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

    //�ϴ��� ��ü ����
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
