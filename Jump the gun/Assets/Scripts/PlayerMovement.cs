using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float MoveSpeed = 6f;
    [SerializeField] private float RBDrag = 6f;
    [SerializeField] private float MoveSpeedMultipler = 10f;

    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;

    Vector3 MoveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();
        ControlDrag();
    }

    void ControlDrag()
    {
        rb.drag = RBDrag;
    }

    void PlayerInput()
    {
        HorizontalSpeed = Input.GetAxisRaw("Horizontal");
        VerticalSpeed = Input.GetAxisRaw("Vertical");

        MoveDirection = transform.forward * VerticalSpeed + transform.right * HorizontalSpeed;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        rb.AddForce(MoveDirection.normalized * MoveSpeed * Time.deltaTime * MoveSpeedMultipler, ForceMode.Acceleration);
    }
}
