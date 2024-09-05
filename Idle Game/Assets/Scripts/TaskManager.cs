using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    [SerializeField] private Transform GoldSpawnPosition;
    [SerializeField] private GameObject GoldObject;

    
   
    private int pickTasks = 1;
    public List<MaterialsToSpawn> TaskObjects;
    private void Awake()
    {
        instance = this;
        CoinPlatform.OnIsTrigged += GetMaterial;
        CheckTaskForNewTask();



    }
  



    void GetMaterial(Clickable clickable)
    {
        foreach(var item in TaskObjects.ToList())
        {
            if(clickable.Material() == item.Material())
            {
                
                TaskObjects.Remove(item);
                CheckTaskForNewTask();
                UIManager.Instance.UpdateTextOfTask();
                break;
            }
        }

    }


    void GetNewTasks()
    {
        
        for (int i = 0; i < pickTasks; i++)
        {
            TaskObjects.Add(MaterialManager.instance.objectsToSpawn[Random.Range(0, MaterialManager.instance.objectsToSpawn.Count())]);

        }
    }
    

    void CheckTaskForNewTask()
    {
        if(TaskObjects.Count <= 0) {
            SpawnGold();
            pickTasks++;
            GetNewTasks();
        }
    }
    

    void SpawnGold()
    {
        
        Instantiate(GoldObject, GoldSpawnPosition.position, Quaternion.identity);
    }


}
