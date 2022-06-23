using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] float SensX = 6f;
    [SerializeField] float SensY = 6f;

    [SerializeField] Transform PlayerCam;

    [SerializeField] float rotationMultiplier = 6f;
    [SerializeField] Transform orientation;

    float mouseX;
    float mouseY;
    float rotationX;
    float rotationY;
    bool cameraLock = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (cameraLock == true)
        {
            MouseInput();

            PlayerCam.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            orientation.transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }
        PauseInput();
    }

    void MouseInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        rotationY += mouseX * SensX * rotationMultiplier;
        rotationX -= mouseY * SensY * rotationMultiplier;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cameraLock == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cameraLock = true;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                cameraLock = false;
                Cursor.visible = true;
            }
        }
    }
}
