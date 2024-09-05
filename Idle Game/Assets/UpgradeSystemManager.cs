using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSystemManager : MonoBehaviour
{
    public TextMeshProUGUI goldtext;
    public TextMeshProUGUI jumptext;
    public TextMeshProUGUI clicktext;

    public int SpeedPrice;
    public int JumpPrice;
    public int ClickPrice;
    public static UpgradeSystemManager instance;
    public static int GoldEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MaterialsToSpawn>() != null)
        {
            if (other.GetComponent<MaterialsToSpawn>().Material() == Clickable.Materials.Gold)
            {
                GoldEntered++;
                UIManager.Instance.UpdateTextOfGold();

                Debug.Log(GoldEntered + " amount of gold has entered in");
                Destroy(other.gameObject,0.2f);

            }
        }
        
       
    }
    private void Awake()
    {
        instance = this;
    }
    public void SetSpeed()
    {
        if(GoldEntered >= SpeedPrice)
        {
            PlayerController.instance.movementSpeed = PlayerController.instance.movementSpeed + PlayerController.instance.movementSpeed*0.15f;
            GoldEntered -= SpeedPrice;
            SpeedPrice += 2;
            goldtext.text = SpeedPrice.ToString() + " GOLD";
            UIManager.Instance.UpdateTextOfGold();

        }
    }

    public void SetJump()
    {
        if (GoldEntered >= JumpPrice)
        {
            PlayerController.instance.jumpForce = PlayerController.instance.jumpForce + PlayerController.instance.jumpForce*.05f;
            GoldEntered -= JumpPrice;
            JumpPrice += 2;
            jumptext.text = JumpPrice.ToString() + " GOLD";
            UIManager.Instance.UpdateTextOfGold();
        }
    }
    public void SetClick()
    {
        if (GoldEntered >= ClickPrice)
        {
            Buttons.Repeat +=1;
            GoldEntered -= ClickPrice;
            ClickPrice += 5;
            clicktext.text = ClickPrice.ToString() + " GOLD";
            UIManager.Instance.UpdateTextOfGold();

        }
    }

}
