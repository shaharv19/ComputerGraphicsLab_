using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public GameObject bow;
    public GameObject arrowObject;
    public Transform arrowPoint;
    public bool isPullingString = false;
    private Animator animator;
  //  public GameObject arrawObject;
   // public Transform arrowPoint;
    public bool IsRight = false;
    Renderer renderer;
    public CharacterController controller;
    public Rigidbody rb;
    public Transform _bow;
    public Transform bowTip;
    public Rigidbody wall1;
    public Rigidbody wall2;
    public Rigidbody wall3;
    public bool IsForward = false;
    public Rigidbody wall4;
    public int speed = 5;
    public Vector2 move;
    private bool can_jump = true;
    private bool is_jumping = false;
    private float currentY = 12.63874f;
    public float crouchHeight = 8.0f;
    public float gravity_multiplier = 3.0f;
    private bool leftMouseTrigged = false;
    private bool leftMouseReleased = true;
    private Vector3 jump;
    float elapsedTime;
    private Vector3 _gravity;
    public float jump_value = 10f;
    public bool rightClick = false;
    private float _velocity = 0.0f;
    Vector3 _move;
    public Bow bowScript;
    public bool IsAiming=false;
    public float startTime = 0;
    public float pressTime = 0;
    public int check = 0;
    public float ArrowTrajectory;
    public Transform left;
    public float speedArrow = 30;


    [SerializeField] CameraPlace cam;

    public void PullStringg()
    {
        left.localRotation = Quaternion.Euler(cam.xRoatation, 0f, 0f);
        Debug.Log("pulling string");
        startTime = Time.time;
        bowScript.PullString();
        isPullingString = true;
        FindObjectOfType<AudioManagerMain>().Play("pull");

    }

    public void Release()
    {
        FindObjectOfType<AudioManagerMain>().Stop("pull");
        FindObjectOfType<AudioManagerMain>().PlayOneTime("release");
        Debug.Log("realising string");
        bowScript.ReleaseString();
        isPullingString = false;
        check = 1;
    }

    public void ArrowShot()
    {
        GameObject arrow = Instantiate(arrowObject, arrowPoint.position, transform.rotation);


       // Debug.Log("degreee" + cam.getX);

        arrow.GetComponent<Rigidbody>().isKinematic = false;
        //arrow.GetComponent<Rigidbody>().velocity = (transform.up * -cam.getX / 6 + transform.forward * 5);
       // if (pressTime < 2)
        //{
            // arrow.GetComponent<Rigidbody>().AddForce(transform.up * -cam.getX * speedArrow, ForceMode.Acceleration);
            // arrow.GetComponent<Rigidbody>().velocity = transform.forward * speedArrow * (pressTime - 0.2f);//pressTime*30;

            arrow.GetComponent<Rigidbody>().AddForce(transform.up * -cam.getX * 50, ForceMode.Acceleration);
            arrow.GetComponent<Rigidbody>().velocity = transform.forward * speedArrow * (pressTime - 0.2f)*pressTime;//pressTime*30;
        //}
        //else
       // {
       //     arrow.GetComponent<Rigidbody>().velocity = transform.up * -cam.getX / 6 + transform.forward * 13 * pressTime;
       //     arrow.GetComponent<Rigidbody>().useGravity = false;

      //  }
    }









    public void onMove(InputAction.CallbackContext context)
    {
        //Debug.Log("move");
        move = context.ReadValue<Vector2>();
       /* if (move.y == 1)
        {
            // animator.SetBool("isMovingForward", true);
            IsForward = true;
            rb.AddForce(transform.forward * 2);
        }*/

        _move = transform.right * move.x*10 + transform.forward * move.y*10;
    }

    public void crouch()
    {

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        //FreezeRotation();


    }

    private void FreezeRotation()
    {
        // Get the current rotation of the object
        Quaternion currentRotation = transform.rotation;

        // Zero out the rotation along the specified axes
        currentRotation = FreezeRotationAlongAxes(currentRotation, true, false, true);

        // Set the modified rotation back to the object
        transform.rotation = currentRotation;
    }

    private Quaternion FreezeRotationAlongAxes(Quaternion rotation, bool freezeX, bool freezeY, bool freezeZ)
    {
        Vector3 eulerRotation = rotation.eulerAngles;

        if (freezeX)
            eulerRotation.x = 0f;
        if (freezeY)
            eulerRotation.y = 0f;
        if (freezeZ)
            eulerRotation.z = 0f;

        return Quaternion.Euler(eulerRotation);
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
           // Debug.Log("collsion traaaaing");
            can_jump = true;
            is_jumping = false;
            //  Debug.Log("collide");
        }
         // Debug.Log("player colliding with:"+collision.gameObject.name); 

    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            //Debug.Log("exit");
            can_jump = false;
            is_jumping = true;
            animator.SetBool("jump", false);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (IsAiming==true)
        {
            animator.SetBool("rightMouseClick", true);
        }
        if (Input.GetKeyDown("left shift"))
        {
            animator.SetBool("isCrouching", true);
            bow.SetActive(false);
            
        }
        if (Input.GetKeyUp("left shift"))
        {
            animator.SetBool("isCrouching", false);
            bow.SetActive(true);

        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("rightMouseClick", true);
            rightClick = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("rightMouseClick", false);
            rightClick = false;
        }

        if (Input.GetButtonDown("Jump") && can_jump == true)
        {
            Debug.Log("jump");
            _move.y = 15f;
            is_jumping = true;
            animator.SetBool("jump", true);
        }
        controller.Move(_move * speed * Time.deltaTime);
        if (is_jumping == true)
        {
            _move.y = _move.y - 1.8f;
        }

       // rb.freezeRotation = false;
        wall1.isKinematic = true;
        wall2.isKinematic = true;
        wall3.isKinematic = true;
        wall4.isKinematic = true;

        //        _move.y = _move.y - 1.8f;
        if (isPullingString == false && check == 1)
        {
            pressTime = Time.time - startTime;
            check = 0;
        }



    }
    public void EnableArrow()
    {
        bowScript.PickArrow();
    }

    public void DisableArrow()
    {
        bowScript.DisableArrow();
    }

   
}
