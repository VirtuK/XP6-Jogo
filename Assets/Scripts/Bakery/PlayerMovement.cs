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
    public bool canMove = false;
    public Transform Camera;
    [SerializeField] private GameObject controlScreen;
    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (BakeryManager.instance.started)
        {
          
            canMove = true;
            controlScreen.SetActive(false);
            
        }
        else
        {
            canMove = false;
            controlScreen.SetActive(true);  
        }
    }

    void Update()
    {
        if (!BakeryManager.instance.started)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                canMove = true;
                controlScreen.SetActive(false);
                BakeryManager.instance.started = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canMove = false;
                controlScreen.SetActive(true);
                BakeryManager.instance.started = false;
            }
        }
        if (canMove)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

             float curSpeedX = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
             float curSpeedY = canMove ? (walkSpeed) * Input.GetAxis("Horizontal") : 0;
             moveDirection = (forward * curSpeedX) + (right * curSpeedY);

             characterController.Move(moveDirection * Time.deltaTime);

        
            float inputX = Input.GetAxis("Mouse X") * mouseSense;
            float inputY = Input.GetAxis("Mouse Y") * mouseSense;
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -45f, 45f);
            Camera.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
            this.transform.Rotate(Vector3.up * inputX);
        }
    } 
}
