using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI taskTexts;
    [SerializeField] private TextMeshProUGUI gold;


    void Awake()
    {
        Instance = this;
        UpdateTextOfTask();
    }


    public void UpdateTextOfTask()
    {
        taskTexts.text = null;
        foreach (var taskText in TaskManager.instance.TaskObjects)
        {
            taskTexts.text += "\n" +taskText.name ;
        }

    }
    public void UpdateTextOfGold()
    {
        gold.text = "GOLD: " + UpgradeSystemManager.GoldEntered.ToString();
    }
}
