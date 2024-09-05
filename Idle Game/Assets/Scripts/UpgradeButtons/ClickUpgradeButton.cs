using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickUpgradeButton : MonoBehaviour,Clickable
{
    public void Click()
    {
        UpgradeSystemManager.instance.SetClick();
    }

    public Clickable.Materials Material()
    {
        throw new System.NotImplementedException();
    }

    public int Priority()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
  
}
