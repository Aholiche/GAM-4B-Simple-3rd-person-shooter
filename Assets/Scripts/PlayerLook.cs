using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;
    public Vector2 sensitivity;

    private Vector2 xyRotation;

    void Start()
    {
        
    }

    // Had trouble working with the camera system. Although this works, I had to use many online resources and concepts I don't understand completely. 
    void Update()
    {
        Vector2 mouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"), y = Input.GetAxis("Mouse Y")
        };

        xyRotation.x -= mouseInput.y * sensitivity.y;
        xyRotation.y += mouseInput.x * sensitivity.x;

        xyRotation.x = Mathf.Clamp(xyRotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, xyRotation.y, 0f);
        playerCamera.localEulerAngles = new Vector3(xyRotation.x, 0f, 0f);
    }
}
