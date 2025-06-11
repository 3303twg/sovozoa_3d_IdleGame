using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    public GameObject statUI;

    public TextMeshProUGUI statText;
    public PlayerController playerController;
    private void OnEnable()
    {
        
            
    }

    public void ShowStatUI()
    {
        statText.text =
            "power : " + playerController.stat.attackPower.ToString() + "\n" +
            "Speed : " + playerController.stat.attackSpeed.ToString() + "\n" +
            "Critical : " + playerController.stat.criticalChance.ToString() + "\n" +
            "CriticalRatio : " + playerController.stat.criticalRatio.ToString() + "\n" +
            "Accuracy : " + playerController.stat.accuracy.ToString() + "\n";
        statUI.SetActive(true);
    }

    public void HideStatUI()
    {
        statUI.SetActive(false);
    }
}
