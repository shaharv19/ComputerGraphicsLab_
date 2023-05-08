using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    public Rigidbody wall1;
    public Rigidbody wall2;
    public Rigidbody wall3;
    public Rigidbody wall4;
    public int speed = 5;
    public Vector2 move;
    private bool canJump;
    private float currentY = 12.63874f;
    public float gravity = -9.8f;
    private Vector3 jump;
    private Vector3 _gravity;
    public float jump_value = 0.5f;
    private int check;
    // Start is called before the first frame update

    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void onJump()
    {
        check = 1;
        Debug.Log("shaloom");
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        canJump = true;
        controller.Move(jump * jump_value*Time.deltaTime);
        Debug.Log("shaloomB");
        //  rb.AddForce(jump * jump_value,ForceMode.Impulse);

    }

    public void OnDisable()
    {
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        controller.Move((transform.right * move.x + transform.forward * move.y) * speed * Time.deltaTime);
   
        /*if ((rb.position.y-currentY>0 && rb.position.y-currentY<0.1)|| rb.position.y<currentY)
        {
            rb.useGravity = false;
           // transform.position = new Vector3(rb.position.x, currentY, rb.position.z);
        }*/
        rb.freezeRotation = true;
        wall1.isKinematic = true;
        wall2.isKinematic = true;
        wall3.isKinematic = true;
        wall4.isKinematic = true;
        if (check == 1)
        {
            Debug.Log("shaloomC");
            check--;
        }
        
    }
    void movePlayer()
    {

        /* Vector3 movment = new Vector3(move.x, 0f, move.y).normalized;
          //transform.Translate(movment * speed * Time.deltaTime, Space.World);
         rb.velocity=(movment * speed * Time.deltaTime)*100;*/
    }
}
