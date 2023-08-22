using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMotion : MonoBehaviour
{
    public Vector3 error;
    public float rotateX = 0;
    public float rotateY = 0;
    public float rotateZ = 0;
    public GameObject _arrow;
    public Transform player;
    NavMeshAgent agent;
    Animator animator;

    private bool isClose = false;
    private bool afterCollision;
    private float time = 0;
    public bool isMoveUp = false;
    public bool isMoveDown = false;
    public bool inCollisionWithObstacle;
    public bool enemyMoveLeft = false;
    public bool enemyMoveRight = false;
    public bool enemyMoveFoward = false;
    public bool enemyMoveDown = false;
    public int counter = 0;
    private int level;
    private int randomInt;
    private float distaceSofar;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        if (agent.enabled )//&& agent.isOnNavMesh)
        {
            agent.destination = player.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        if (inCollisionWithObstacle==true)
        {
            if(enemyMoveDown==true)
            {
                Vector3 newPosition = transform.position + Vector3.back * 2.0f;
                transform.position = newPosition;

            }
            if(enemyMoveFoward==true)
            {
                Vector3 newPosition = transform.position + Vector3.forward * 2.0f;
                transform.position = newPosition;

            }
            if (enemyMoveLeft==true)
            {
                Vector3 newPosition = transform.position + Vector3.left * 2.0f;
                transform.position = newPosition;
            }
            if(enemyMoveRight==true)
            {
                Vector3 newPosition = transform.position + Vector3.right * 2.0f;
                transform.position = newPosition;
            }
        }
        if(inCollisionWithObstacle==false)
        {
            enemyMoveDown = false;
            enemyMoveFoward = false;
            enemyMoveLeft = false;
            enemyMoveRight = false;
        }
        float distance = Vector3.Distance(transform.position, player.position);
        distaceSofar = distance;

        // Print the distance to the console
        if (counter==0)
        {
            if (distance <= 20f)
            {
                counter =1;
               // agent.isStopped = true;
                agent.enabled = false;
                animator.SetBool("IsClose", true);
            }
        }
        if(counter==1)
        {
            if(distance>20f)
            {
                //agent.isStopped = false;
                agent.enabled = true;
                animator.SetBool("IsClose", false);
                counter = 0;
            }
        }
         if(isMoveUp==true)
         {
             Vector3 newPosition = transform.position + Vector3.forward * 2.0f;
             transform.position = newPosition;
             isMoveUp = false;
         }
         if (isMoveDown == true)
         {
             Vector3 newPosition = transform.position + Vector3.back * 2.0f;
             transform.position = newPosition;
             isMoveDown = false;
         }

    }


    public void AiShoot()
    {
        level = StateNameController.level;
        if(level==1)
        {
             randomInt = Random.Range(0, 6);
        }
        if(level==2)
        {
             randomInt = Random.Range(0, 4);
        }
        if(level==3)
        {
             randomInt = Random.Range(0, 2);
        }
        if (randomInt == 0 || distaceSofar < 10)
        {
            error.x = 0;
        }
        else
        {
            error.x = 15;
        }
        
        GameObject arrow = Instantiate(_arrow, transform.position, transform.rotation);
        Vector3 direction = (player.transform.position -transform.position+error).normalized;
        direction.y = 0;


        arrow.GetComponent<Rigidbody>().isKinematic = false;
        arrow.GetComponent<Rigidbody>().useGravity = false;

        arrow.GetComponent<Rigidbody>().velocity = direction * 2f;
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

    /*  private void OnCollisionEnter(Collision collision)
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
               }
          }
      }*/

    public void OnCollisionEnter(Collision collision)
    {
        bool rightHit = false;
        bool backHit = false;
        bool leftHit = false;
        bool frontHit=false;
        if (collision.gameObject.tag == "cube")
        {
            inCollisionWithObstacle = true;

          
               /// agent.isStopped = true;
                agent.enabled = false;
            
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 contactNormal = contact.normal;

                // Check the absolute values of the contact normal components
                float absX = Mathf.Abs(contactNormal.x);
                float absY = Mathf.Abs(contactNormal.y);
                float absZ = Mathf.Abs(contactNormal.z);

                // Compare the absolute values to determine the hit face
                if (absX > absY && absX > absZ)
                {
                    // Hit on the x-axis
                    if (contactNormal.x > 0)
                    {
                        // Hit on the right face
                        rightHit = true;
                    }
                    else
                    {
                        // Hit on the left face
                        leftHit = true;
                    }
                }
                else if (absY > absX && absY > absZ)
                {
                    // Hit on the y-axis
                    if (contactNormal.y > 0)
                    {
                        // Hit on the top face
                    }
                    else
                    {
                        // Hit on the bottom face
                    }
                }
                else
                {
                    // Hit on the z-axis
                    if (contactNormal.z > 0)
                    {
                        // Hit on the front face
                        frontHit = true;
                    }
                    else
                    {
                        // Hit on the back face
                        backHit = true;
                    }
                }
            }
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
                if (frontHit == true || backHit == true)
                {
                    /* Vector3 newPosition = transform.position + Vector3.left * 2.0f;
                     transform.position = newPosition;*/
                    enemyMoveLeft = true;
                }
                if(leftHit==true || rightHit==true)
                {
                    /*Vector3 newPosition = transform.position + Vector3.forward * 2.0f;
                    transform.position = newPosition;*/
                    enemyMoveFoward = true;
                }

            }
            else
            {
                if (frontHit == true || backHit == true)
                {
                    /*Vector3 newPosition = transform.position + Vector3.right * 2.0f;
                    transform.position = newPosition;*/
                    enemyMoveRight = true;
                }
                if (leftHit == true || rightHit == true)
                {
                    /* Vector3 newPosition = transform.position + Vector3.back * 2.0f;
                     transform.position = newPosition;*/
                    enemyMoveDown = true;
                }
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            inCollisionWithObstacle = false;
            //Debug.Log("out collision with:" + collision.gameObject.name);
            agent.enabled = true;
              //  agent.isStopped = false;
            
        }
    }

   

}
