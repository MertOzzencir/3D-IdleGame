using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Buttons : MonoBehaviour,Clickable
{

    public static event Action<Clickable.Materials,Transform> OnClickButton;

    public static int Repeat = 1;
    
    [SerializeField] private GameObject MainObject;
    [SerializeField] private float ClickToAchieve;
    [SerializeField] private Clickable.Materials ButtonMaterial;
    [SerializeField] private TextMeshProUGUI text;
    public Transform _spawnPoint;

    Animator anim;

    private int counter;
    private void Start()
    {
        anim = MainObject.GetComponent<Animator>();
    }

    public void Click()
    {
       
        anim.SetTrigger("sa");
        for (int i = 0; i < Repeat; i++)
        {
            counter++;

        }
        text.text = counter.ToString() + "/" + ClickToAchieve;
        
        if (counter >= ClickToAchieve )
        {
            Destroy(MainObject.gameObject,  0.05f);
            OnClickButton?.Invoke(ButtonMaterial, _spawnPoint);
            counter = 0;
        }
           
      


    }
    private void OnDestroy()
    {
       switch(ButtonMaterial)
        {

            case Clickable.Materials.Wood:
                EnviroenmentSpawner.TreeSpawned--;
                break;
            case Clickable.Materials.Rock:
                EnviroenmentSpawner.RockSpawned--;
                break;

        }
    }





    Clickable.Materials Clickable.Material()
    {
        return ButtonMaterial;
    }

    public int Priority()
    {
        return 0;
    }
}
