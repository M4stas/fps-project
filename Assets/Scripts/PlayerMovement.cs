using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public float crouchSpeed = 2.5f;

    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    public float standingHeight = 1.8f;
    public float crouchingHeight = 0f;
    public float heightChangeSpeed = 0f;

    CharacterController cc;
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.AddComponent<CharacterController>();
        cc.height = standingHeight;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = cc.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        float currentSpeed = walkSpeed;

        //sprint
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = crouchSpeed;
        }

        //crouch
        bool crouching = Input.GetKey(KeyCode.LeftControl);
        if (crouching)
        {
            currentSpeed = crouchSpeed;
        }
        cc.Move(move * currentSpeed * Time.deltaTime);
    }
}
