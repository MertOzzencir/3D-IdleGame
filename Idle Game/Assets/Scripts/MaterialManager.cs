using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager instance;
    public MaterialsToSpawn[] objectsToSpawn;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void OnEnable()
    {
        Buttons.OnClickButton += Instanita;
    }

    private void OnDisable()
    {
        Buttons.OnClickButton -= Instanita;
    }

    public void Instanita(Clickable.Materials Material,Transform position)
    {
        foreach(var item in objectsToSpawn)
        {
            if(item.Material() == Material)
            {
                Instantiate(item.gameObject, position.position, Quaternion.identity);
            }
        }

    }


}
