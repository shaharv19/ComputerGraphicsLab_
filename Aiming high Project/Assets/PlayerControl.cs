using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Animator animator;
  //  public GameObject arrawObject;
   // public Transform arrowPoint;
    public bool IsRight = false;
    public CharacterController controller;
    public Rigidbody rb;
    public Rigidbody wall1;
    public Rigidbody wall2;
    public Rigidbody wall3;
    public bool IsForward = false;
    public Rigidbody wall4;
    public int speed = 5;
    public Vector2 move;
    private bool can_jump = false;
    private bool is_jumping = false;
    private float currentY = 12.63874f;
    public float crouchHeight = 8.0f;
    public float gravity_multiplier = 3.0f;
    private bool leftMouseTrigged = false;
    private bool leftMouseReleased = true;
    private Vector3 jump;
    private Vector3 _gravity;
    public float jump_value = 10f;
    public bool rightClick = false;
    private float _velocity = 0.0f;
    Vector3 _move;

   // [SerializeField] cameraSet cameraA;

    // Start is called before the first frame update

    /*public void ThrowArrow()
    {
        Debug.Log(" jkdfjkdjskarraw");
        GameObject arrow = Instantiate(arrawObject, arrowPoint.position + new Vector3(0f, 0f, 0f), transform.rotation);
         Vector2 vec = new Vector2(0, 1);
          arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 30f/*transform.up*10f*-cameraA.xRoatation, ForceMode.Impulse);



    }

    public void ThrowArr()
    {
        Debug.Log("throw arraw");
        GameObject arrow = Instantiate(arrawObject, arrowPoint.position, transform.rotation);
        // Vector2 vec = new Vector2(0, 1);
        //   arrow.GetComponent<Rigidbody>().AddForce(transform.forward * -1f/*transform.up*10f*-cameraA.xRoatation, ForceMode.Impulse);
    }*/


    public void onMove(InputAction.CallbackContext context)
    {
        //Debug.Log("move");
        move = context.ReadValue<Vector2>();
        // Debug.Log("right equal to:" + move.x);
        // Debug.Log("fowrward to:" + move.y);
        if (move.y == 1)
        {
            // animator.SetBool("isMovingForward", true);
            IsForward = true;
            rb.AddForce(transform.forward * 2);
        }
        else
        {
            // animator.SetBool("isMovingForward", false);
            IsForward = false;
        }
        if (move.x == 1)
        {
            //animator.SetBool("isMovingRight", true);
            IsRight = true;
            Debug.Log("righhhht");
        }
        else
        {
            //animator.SetBool("isMovingRight", false);
            IsRight = false;
        }

        /*  if (move.x == 1)
          {
              animator.SetBool("isMovingRight", false);
              IsRight = false;
          }

          if(move.x==-1)
          {
              animator.SetBool("isMovingLeft", true);
          }
          else
          {
              animator.SetBool("isMovingLeft", false) ;
          }*/
        _move = transform.right * move.x + transform.forward * move.y;
    }

    public void crouch()
    {

    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            can_jump = true;
            is_jumping = false;
            //  Debug.Log("collide");
        }

    }
    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            can_jump = false;
            is_jumping = true;
            animator.SetBool("jump", false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            animator.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp("left shift"))
        {
            animator.SetBool("isCrouching", false);

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
            _move.y = 22.5f;
            is_jumping = true;
            animator.SetBool("jump", true);
        }
        controller.Move(_move * speed * Time.deltaTime);
        if (is_jumping == true)
        {
            _move.y = _move.y - 1.8f;
        }

        rb.freezeRotation = true;
        wall1.isKinematic = true;
        wall2.isKinematic = true;
        wall3.isKinematic = true;
        wall4.isKinematic = true;


    }
}
