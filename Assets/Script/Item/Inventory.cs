using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public GameObject slotPrefab;
    public Transform slotParent;


    //�̺�Ʈ������ �ְ������?
    private void OnEnable()
    {
        EventBus.Subscribe("AddItemEvent", AddItem);
        EventBus.Subscribe("RemoveItemEvent", RemoveItem);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("AddItemEvent", AddItem);
        EventBus.Unsubscribe("RemoveItemEvent", RemoveItem);
    }

    //So�� ���ʿ� ������?
    //������ �߰�
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
                RefrashUI();
                return;
            }
        }
        slots.Add(new Slot(itemData));
        RefrashUI();

    }

    //������ ����
    public void RemoveItem(object obj)
    {
        //ItemData itemData = (ItemData)obj;
        //Slot slot = slots.Find(s => s.itemData == itemData);
        Slot slot = (Slot)obj;
        if (slot != null)
        {
            slot.itemData.cnt--;
            if (slot.itemData.cnt <= 0)
            {
                slots.Remove(slot);
            }
        }
    }

    //�ϴ��� ��ȿ������ ��ü ����
    public void RefrashUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Slot data in slots)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            SlotUI ui = go.GetComponent<SlotUI>();
            ui.Bind(data);
        }
    }
}
