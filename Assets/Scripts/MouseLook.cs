using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 50f;

    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //locks cursor to center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        firstPersonLook();
        
    }

    void firstPersonX()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

    }

    void firstPersonY()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        //look into how this works
        xRotation -= mouseY;

        //inverted up and down
        //xRotation += mouseY;

        //clamps and locks rotation so you cant look up and down past 90degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //rotates around the x local position
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    void firstPersonLook()
    {
        firstPersonX();
        firstPersonY();
    }
  
    
}

  
        

