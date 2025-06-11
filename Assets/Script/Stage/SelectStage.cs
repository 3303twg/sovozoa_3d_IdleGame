using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public GameObject stageUI;

    public List<Button> stageBtns;

    public List<StageDataSo> stageDataSos;

    private void OnEnable()
    {
        for(int i = 0; i < stageBtns.Count; i++)
        {
            int temp = i;
            stageBtns[temp].onClick.AddListener(() => LoadStage(temp));
            stageBtns[temp].onClick.AddListener(() => HideStageUI());
        }

    }
    private void OnDisable()
    {
        
    }

    //버튼호출
    public void ShowStageUI()
    {
        stageUI.SetActive(true);
    }

    public void HideStageUI()
    {
        stageUI.SetActive(false);
    }

    public void LoadStage(int index)
    {
        StageDataBox.Instance.stageDataSo = stageDataSos[index];
    }
}
