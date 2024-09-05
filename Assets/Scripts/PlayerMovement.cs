using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSense = 3f;
    public float walkSpeed;
    float cameraVerticalRotation = 0f;
    bool moving;
    public CharacterController characterController;
    Vector3 moveDirection;
    bool canMove = true;
    public Transform Camera;

    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (walkSpeed) * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSense;
            float inputY = Input.GetAxis("Mouse Y") * mouseSense;
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            Camera.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
            this.transform.Rotate(Vector3.up * inputX);
        }
    } 
}
