using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlace : MonoBehaviour
{
    public Transform player;
    public float getX;
    public bool isAltPressed = false;
    public CharacterController control;
    private bool wasMoving = false;
    public float letsSee = 0.4f;
    public float walkOffset = 0.3f;
    public float mouseSensivity = 100f;
    private int count = 1;
    private int countA = 1;
    private int countB = 1;
    public int frames = 1;
    public int setFrames = 100;
    public float yroatet = 30f;


    public float xRoatation = 0f;
    [SerializeField] PlayerControl controller;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRoatation -= mouseY;
        if (controller.rightClick == true)
        {
            xRoatation = Mathf.Clamp(xRoatation, -16f, 16f);
            getX = xRoatation;
        }
        else
        {
            xRoatation = Mathf.Clamp(xRoatation, -45f, 45f);
        }
        transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        if (count == 1)
        {
            if (Input.GetKeyDown("left shift"))
            {
                transform.position = transform.position + new Vector3(0, -1.0f, 0.2f);
               // Debug.Log("shift");
                isAltPressed = true;
            }
            count = 0;
        }

        if (count == 0)
        {
            if (Input.GetKeyUp("left shift"))
            {
                // controller.height = currentY;
                transform.position = transform.position + new Vector3(0, 1.0f, -0.2f);
               // Debug.Log("shift realsised");
                isAltPressed = false;
            }
            count = 1;
        }
    }

}


