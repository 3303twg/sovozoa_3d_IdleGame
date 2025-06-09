using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //Áßº¹È¹µæÀº ¾ø¾îµµµÉµí?
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

