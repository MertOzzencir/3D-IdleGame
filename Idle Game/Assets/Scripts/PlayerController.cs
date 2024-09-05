using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Values")]
    [SerializeField] public float movementSpeed;
    [SerializeField] public float jumpForce;

    [SerializeField] private Transform orientation;



    [Header("Ground Check")]
    [SerializeField] private float floorDrag;
    [SerializeField] private float playerHeight;
    [SerializeField] private float offSetToGround;

    [SerializeField] public LayerMask groundMask;
    public bool isGroundedBool;



    public Transform ObjectHolder;
    float horizontal;
    float vertical;

    Vector3 moveDirection;
    Rigidbody rb;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        playerHeight = transform.localScale.y;
    }

    void Update()
    {
        ApplyDrag();
        CheckSpeed();
        GetInputs();
        ApplyDrag();


    }

    private void FixedUpdate()
    {
        Move();
    }

    private bool IsGrounded()
    {
        isGroundedBool = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + offSetToGround, groundMask);
        return isGroundedBool;
    }
    private void GetInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            Jump();
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        rb.AddForce(transform.up * jumpForce , ForceMode.Impulse);
    }

    private void Move()
    {
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        if(IsGrounded())
             rb.AddForce(moveDirection * movementSpeed * 10, ForceMode.Force);

    }
   

    private void ApplyDrag()
    {
        if (IsGrounded())
            rb.drag = floorDrag;
        else
            rb.drag = 0;
    }

    private void CheckSpeed()
    {
      
        Vector3 LimitedVelo = new Vector3(rb.velocity.x,0,rb.velocity.z);

        if (LimitedVelo.magnitude > movementSpeed)
        {
            Vector3 direc = LimitedVelo.normalized * movementSpeed;
            rb.velocity = new Vector3(direc.x,rb.velocity.y,direc.z);
        }
    }

   
}
