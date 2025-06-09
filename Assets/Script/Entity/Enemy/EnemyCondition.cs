using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCondition : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI nameBG;
    public Image HPBar;

    private void OnEnable()
    {
        EventBus.Subscribe("RefrashHPEvent", RefrashHP);
        EventBus.Subscribe("EnemyInitEvent", EnemyInit);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe("RefrashHPEvent", RefrashHP);
        EventBus.Unsubscribe("EnemyInitEvent", EnemyInit);
    }

    public void Reduce()
    {

    }

    public void RefrashHP(object obj)
    {
        HPBar.fillAmount = (float)obj;
    }
    public void EnemyInit(object obj)
    {
        EnemyDataSo data = (EnemyDataSo)obj;
        name.text = data.name;
        nameBG.text = data.name;
    }
}
