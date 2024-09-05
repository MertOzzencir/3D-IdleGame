using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsToSpawn : MonoBehaviour,Clickable
{

    [SerializeField] private Clickable.Materials ObjectMaterial;
    [SerializeField] private int priority;

    

    Rigidbody rb;
    BoxCollider cl;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<BoxCollider>();
    }
    bool canLock;
    private void LateUpdate()
    {
        if (canLock)
        {
            Ray ray = SelectObject.instance.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, PlayerController.instance.groundMask))
            {
                Vector3 pos = new Vector3(hit.point.x,3f,hit.point.z);
                transform.position = pos;
               
            }
            if (Input.GetKeyDown(KeyCode.E)){
                canLock = false;

            }
            
            //transform.forward = PlayerController.instance.ObjectHolder.forward;
            //transform.position = PlayerController.instance.ObjectHolder.position;


        }
        else
        {
         
            
        }

    }
    public void Click()
    {
       canLock = !canLock;
    }

    public Clickable.Materials Material()
    {
        return ObjectMaterial;
    }

    public int Priority()
    {
        return priority;

    }
}
