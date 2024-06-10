using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float smoothTime;
    public float gravityStrength;
    public float jumpStrength;
    public float walkSpeed;
    public float runSpeed;
    public float health = 150f;
    public float maxHealth = 150f;

    private CharacterController Controller;
    private Vector3 currentMoveVelocity;
    private Vector3 moveVelocity;

    private Vector3 currentForceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"), y = 0f, z = Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude > 1f)
        { 
            PlayerInput.Normalize();
        }

        Vector3 moveVector = transform.TransformDirection(PlayerInput);
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, moveVector * currentSpeed, ref moveVelocity, smoothTime);

        Controller.Move(currentMoveVelocity * Time.deltaTime);

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(groundCheckRay, 1.25f))
        {
            currentForceVelocity.y = -2f;
            
            if (Input.GetKey(KeyCode.Space))
            {
                currentForceVelocity.y = jumpStrength;
            }
        }
        else
        {
            currentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }

        Controller.Move(currentForceVelocity * Time.deltaTime);
    }
}
