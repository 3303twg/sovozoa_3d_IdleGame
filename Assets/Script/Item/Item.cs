using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    gold,
    dia,

}
public class Item : MonoBehaviour
{
    public ItemDataSo itemDataSo;
    public ItemData itemdata;
    Rigidbody rb;
    public ItemType itemType;
    public int value;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Vector3 baseDirection = transform.up;

        // ���� ���⿡ ������ ���͸� ����
        Vector3 randomOffset = new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.1f, 0.1f),  // Y�� ��鸲�� ���� ���� ����
            Random.Range(-0.5f, 0.5f)
        );

        // ���� ���� ����ȭ
        Vector3 finalDirection = (baseDirection + randomOffset).normalized;

        // ������ ����
        float randomPower = Random.Range(1f, 5f);

        // �� ����
        rb.AddForce(finalDirection * randomPower, ForceMode.Impulse);


        if (itemDataSo)
        {
            itemdata = new ItemData(itemDataSo);
            Invoke("GetItem", 1f);
        }

        else if (itemType == ItemType.gold)
        {
            Invoke("GetGold", 1f);
        }
        

        
    }

    public void GetItem()
    {
        EventBus.Publish("AddItemEvent", itemdata);
        Destroy(gameObject);
    }
    public void GetGold()
    {
        EventBus.Publish("AddGoldEvent", value);
        Destroy(gameObject);
    }
}
