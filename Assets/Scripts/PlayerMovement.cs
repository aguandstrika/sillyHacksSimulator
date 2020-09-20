using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Keyboard Movement Variables

    public GameObject box;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;



    //Ground Check Variables
    //Reference for the ground check object
    public Transform groundCheck;
    // Radius of sphere projecting to do ground check.
    public float groundDistance = 0.4f;
    // This will control what objects the sphere should check for.
    public LayerMask groundMask;
    private bool isGrounded;
    

    //Velocity
    Vector3 velocity;


    // Update is called once per frame
    void Update()
    {

        grounded();
        movement();
        velocityEquation();


    }

    public bool grounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        return isGrounded;
    }

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        jumping();

    }

    void jumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void velocityEquation()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
