using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //�ߺ�ȹ���� ����ɵ�?
    [SerializeField]
    public ItemData itemData;
    public Image icon;
    public bool isEquip = false;

    public TextMeshProUGUI cntText;

    public Slot(ItemData itemData)
    {
        this.itemData = itemData;
    }


    public void Update()
    {
        //icon.SetActive(isEquip);
    }
}

