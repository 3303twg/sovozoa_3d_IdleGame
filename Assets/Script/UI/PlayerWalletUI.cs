using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

//플레이어의 자산을 표기할곳
public class PlayerWalletUI : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Diamond;

    private void OnEnable()
    {
        EventBus.Subscribe("AddGoldEvent", RefrashGold);
        EventBus.Subscribe("AddDiamondEvent", RefrashDiamond);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("AddGoldEvent", RefrashGold);
        EventBus.Unsubscribe("AddDiamondEvent", RefrashDiamond);
    }

    void Start()
    {
        
    }

    //갱신
    public void RefrashGold(object obj)
    {
        Gold.text = (int.Parse(Gold.text.Replace("G", "").Trim()) + (int)obj).ToString() + "G";
    }

    //갱신
    public void RefrashDiamond(object obj)
    {
        Diamond.text = (int.Parse(Diamond.text) + (int)obj).ToString();
    }
}
