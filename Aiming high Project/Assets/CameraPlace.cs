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
            xRoatation = Mathf.Clamp(xRoatation, -22.5f, 22.5f);
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


        /*  if (controller.IsForward==true && countA==1)
          {
            control.Move(new Vector3(0, 0,-5));
            //transform.position= transform.position + new Vector3(0,0, walkOffset);
            Debug.Log("here");
            countA = 0;
        }

          else if (controller.IsForward == false && countA == 0)
          {
            control.Move(new Vector3(0,0,5));
            //transform.position = transform.position + new Vector3(0, 0, -walkOffset);
            countA = 1;
              Debug.Log("here2");
          }
          /*
        if (controller.IsRight == true && countB== 1)
        {
            transform.position = transform.position + new Vector3(walkOffset+0.08f, 0, walkOffset/2+0.08f);
            countB = 0;
            Debug.Log("here");
        }

        else if (controller.IsRight == false && countB == 0)
        {
            transform.position = transform.position + new Vector3(-walkOffset - 0.08f, 0, -walkOffset / 2 - 0.08f);
            countB = 1;
            Debug.Log("here2");
        }
         */


    }
}

