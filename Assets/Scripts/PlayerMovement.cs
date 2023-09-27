using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    private float runSpeed;
    private float currentSpeed;
    public float rotationSpeed;
    public float cameraSpeed;
    private Vector2 movementValue;
    private Vector2 lookValue;
    public Camera myCamera;
    private bool isRunning = false;


    private Rigidbody rb;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = walkSpeed;

        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log(value);
        movementValue = value.Get<Vector2>() * currentSpeed;
    }
    
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>() * rotationSpeed;
    }

    public void OnRun()
    {
        runSpeed = walkSpeed + 20;
        if (isRunning)
        {
            currentSpeed = walkSpeed;
            isRunning = false;
        }
        else
        {
            currentSpeed = runSpeed;
            isRunning = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(movementValue.x * 100 * Time.deltaTime, 0, movementValue.y * 100 * Time.deltaTime);

        rb.AddRelativeTorque(0, lookValue.x * Time.deltaTime, 0);


        //transform.Translate(
        //    movementValue.x * Time.deltaTime,
        //    0,
        //    movementValue.y * Time.deltaTime);

        //transform.Rotate(0, lookValue.x * Time.deltaTime, 0);

        myCamera.transform.Rotate(-lookValue.y * Time.deltaTime, 0, 0);

    }
}
