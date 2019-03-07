using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float mouseSensitivity = 3;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        bool sprint = Input.GetKey(KeyCode.LeftShift);

        Vector3 movHorizontal = transform.right * xMov; // (1, 0, 0)
        Vector3 movVertical = transform.forward * zMov; // (0, 0, 1)
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed; //Direction multiplied by speed

        motor.Move(velocity);

        // gotta get rotation on a 3d vector (Turning around... on the x)
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;
        motor.Rotate(rotation);

        // gotta get rotation on a 3d vector (Camera rotation)
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivity;
        motor.RotateCamera(cameraRotation);

        if (sprint)
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
    }
}
