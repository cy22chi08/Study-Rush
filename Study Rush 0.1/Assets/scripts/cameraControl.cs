using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float sensitivity = 2.0f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
            
            rotationX -= mouseY;
            rotationY += mouseX;
            
            rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Prevent flipping
            
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}
