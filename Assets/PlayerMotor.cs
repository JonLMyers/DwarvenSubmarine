using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camera_rotation = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    //takes a movement vector 
    public void Move(Vector3 input_velocity)
    {
        velocity = input_velocity;
    }

    //Gets rotation vector
    public void Rotate(Vector3 input_rotation)
    {
        rotation = input_rotation;
    }

    //Gets camera Rotation Vector
    public void RotateCamera(Vector3 input_rotation)
    {
        camera_rotation = input_rotation;
    }

    //This runs every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform the movement
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        // Rotations go through quaternion?  Vector3's with an imaginary component.  Euler is the x/y we know
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-camera_rotation);
        }
    }
}
