using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerObject;
    [SerializeField] private Transform player;
    [SerializeField] private float turnSpeed;
  

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x,player.position.y,transform.position.z);
        orientation.forward = viewDir.normalized;
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 input = orientation.forward * Vertical + orientation.right*Horizontal;

        if (input != Vector3.zero)
            playerObject.forward = Vector3.Slerp(playerObject.forward, input.normalized, Time.deltaTime * turnSpeed);



        
    }



}
