using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float MoveSpeed = 6f;
    [SerializeField] private float MoveSpeedMultiplier = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float airMoveMultiplier = 0.3f;

    [Header("Sprint")]
    [SerializeField] private float normalSpeed = 6f;
    [SerializeField] private float sprintSpeed = 10f;

    [Header("Monitoring")]
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;

    [Header("Drag")]
    [SerializeField] private float groundDrag = 6f;
    [SerializeField] private float airDrag = 3f;

    [Header("Ground Stuff")]
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;

    [Header("Misc")]
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private Transform orientation;

    Vector3 MoveDirection;
    Vector3 SlopeMoveDirection;

    Rigidbody rb;
    bool isGrounded;
    RaycastHit slopeHit;



    private bool onSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHeight = GetComponentInChildren<CapsuleCollider>().height;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0),groundDistance,groundMask);

        PlayerInput();
        ControlDrag();
        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void PlayerInput()
    {
        HorizontalSpeed = Input.GetAxisRaw("Horizontal");
        VerticalSpeed = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = sprintSpeed;
        }
        else
        {
            MoveSpeed = normalSpeed;
        }
        print(MoveSpeed);

        MoveDirection = orientation.forward * VerticalSpeed + orientation.right * HorizontalSpeed;

    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (isGrounded)
        {
            rb.AddForce(MoveDirection.normalized * MoveSpeed * Time.deltaTime * MoveSpeedMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(MoveDirection.normalized * MoveSpeed * Time.deltaTime * MoveSpeedMultiplier * airMoveMultiplier, ForceMode.Acceleration);
        }
    }
}
