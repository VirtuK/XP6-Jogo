using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject finishScreen;

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

        if (!BakeryManager.instance.started && BakeryManager.instance.taskCount < 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
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

        if(BakeryManager.instance.taskCount >= 5)
        {
            canMove = false;
            finishScreen.SetActive(true);
            BakeryManager.instance.started = false;
            BakeryManager.instance.finished = false;
        }

        if (BakeryManager.instance.finished)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BakeryManager.instance.ResetValues();
                SceneManager.LoadScene("SampleScene");
            }
        }

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