using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlatform : MonoBehaviour
{
    public static event Action<Clickable> OnIsTrigged;





    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Clickable>() != null)
        {
            OnIsTrigged?.Invoke(other.gameObject.GetComponent<Clickable>());

            Destroy(other.gameObject,1f);

        }
    }

}
