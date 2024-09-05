using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroenmentSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] Woodpoints;
    [SerializeField] private Transform[] Rockpoints;

    [SerializeField] private GameObject[] spawnObjects;
    public static int TreeSpawned;
    public static int RockSpawned;
    private void OnDrawGizmos()
    {
        for(int i = 0; i < Woodpoints.Length; i++)
        {
            if (i == Woodpoints.Length - 1)
            {
                Gizmos.DrawLine(Woodpoints[i].position, Woodpoints[0].position);
                continue;
            }
            Gizmos.DrawLine(Woodpoints[i].position, Woodpoints[i + 1].position);
            

        }
        for (int i = 0; i < Rockpoints.Length; i++)
        {
            if (i == Rockpoints.Length - 1)
            {
                Gizmos.DrawLine(Rockpoints[i].position, Rockpoints[0].position);
                continue;
            }
            Gizmos.DrawLine(Rockpoints[i].position, Rockpoints[i + 1].position);


        }
    }
    private void Update()
    {
        if(TreeSpawned <1)
        for(int i = 0;i<10;i++)
        {
                TreeSpawned++;
            ObjectSpawn(Woodpoints, spawnObjects[0]);
        }
        else if (RockSpawned < 1) {
            for (int i = 0; i < 10; i++)
            {
                RockSpawned++;
                ObjectSpawn(Rockpoints, spawnObjects[1]);
            }
         
        }
    }


    private void ObjectSpawn(Transform[] objectTransform,GameObject toSpawn)
    {

        float x = Random.Range(objectTransform[0].position.x, objectTransform[3].position.x);
        float z = Random.Range(objectTransform[0].position.z, objectTransform[1].position.z);
        Vector3 position = new Vector3(x,0.35f,z);

        Instantiate(toSpawn, position, Quaternion.identity);
    }
}
