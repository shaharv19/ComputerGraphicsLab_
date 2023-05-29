using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMotion : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    Animator animator;
    private bool inCollsion = false;
    private bool afterCollision;
    private float time = 0;
    public bool isMoveUp = false;
    public bool isMoveDown = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMoveUp == true)
        {
            Vector3 newPosition = transform.position + Vector3.forward * 2.0f;
            // Move the player to the new position
            transform.position = newPosition;
            isMoveUp = false;

        }
        if(isMoveDown==true)
        {
            Vector3 newPosition = transform.position + Vector3.back * 2.0f;
            // Move the player to the new position
            transform.position = newPosition;
            isMoveDown = false;
        }
        if(inCollsion==true)
        {

        }   

        if (agent.enabled && agent.isOnNavMesh)
        {
            agent.destination = player.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }


    }
    /*private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves an obstacle
        Debug.Log("collsion the monster with:" + collision.gameObject.name);
        if (collision.gameObject.name == "Cube (1)")
        {
            ContactPoint contactPoint = collision.contacts[0];

            // Check if the collided object is the specific object you're interested in
            GameObject collidedObject = collision.gameObject;
          
            
                // Calculate the center of the specific object
                Vector3 center = collidedObject.GetComponent<Collider>().bounds.center;

                // Compare the contact point's x-coordinate with the center's x-coordinate
                bool hitOnLeft = contactPoint.point.x < center.x;
                bool hitOnRight = contactPoint.point.x > center.x;

                // Do something based on the result
                if (hitOnLeft)
                {
                    Debug.Log("Player hit the specific object on the left side.");
                Vector3 newPosition = transform.position + Vector3.up * 2.0f;

                // Move the player to the new position
                transform.position = newPosition;


            }
                else if (hitOnRight)
                {
                    Debug.Log("Player hit the specific object on the right side.");
                }
                else
                {
                    Debug.Log("Player hit the specific object exactly at the center.");
                }

                // collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //    Debug.Log("hellooo");
                // Stop the AI movement
                agent.isStopped = true;

                // Disable the NavMeshAgent temporarily to allow for collision response
                agent.enabled = false;

                // Perform collision response or custom behavior here


                // Re-enable the NavMeshAgent
                // agent.enabled = true;
                //agent.isStopped = false;
            
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("stayyy");
        if (collision.gameObject.tag == "cube")
        {
            Debug.Log("in collision with:"+ collision.gameObject.name);
            agent.isStopped = true;

            // Disable the NavMeshAgent temporarily to allow for collision response
            agent.enabled = false;

            /* inCollsion = true;
             ContactPoint contactPoint = collision.contacts[0];

             // Get the collider of the object being collided with
             Collider otherCollider = contactPoint.otherCollider;
             float hitAreaThreshold = 0.5f; // Adjust this value based on your needs
             bool hitOnLeft = contactPoint.point.x < (collision.gameObject.GetComponent<Collider>().bounds.center.x - hitAreaThreshold);
             bool hitOnRight = contactPoint.point.x > (collision.gameObject.GetComponent<Collider>().bounds.center.x + hitAreaThreshold);


             // Adjust the player's position based on the hit area
             if (hitOnLeft)
             {
             }
             else if (hitOnRight)
             {
             }*/
        }
    }

    private void Solve()
    {
        agent.isStopped = true;
        agent.enabled = false;
        Vector3 newPosition = transform.position + Vector3.up * 2.0f;
        // Move the player to the new position
        transform.position = newPosition;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube (1)")
        {
            Debug.Log("out collision with:" + collision.gameObject.name);
            /* inCollsion = false;
             agent.enabled = true;
             agent.isStopped = false;*/
        }
    }

}
