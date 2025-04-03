using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;

    private CharacterController controller;
    private Transform playerCamera;
    private float xRotation = 0f;
    private bool isLooking = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;

        // Unlock cursor initially
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        PlayerMovement();
        HandleMouseInput();
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left Mouse Button Pressed
        {
            isLooking = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetMouseButtonUp(0)) // Left Mouse Button Released
        {
            isLooking = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (isLooking)
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping over

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
