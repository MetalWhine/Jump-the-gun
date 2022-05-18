using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] float SensX = 6f;
    [SerializeField] float SensY = 6f;

    Camera PlayerCam;

    [SerializeField] float rotationMultiplier = 6f;

    float mouseX;
    float mouseY;
    float rotationX;
    float rotationY;

    private void Start()
    {
        PlayerCam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MouseInput();

        PlayerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void MouseInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        rotationY += mouseX * SensX * rotationMultiplier;
        rotationX -= mouseY * SensY * rotationMultiplier;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
    }
}
