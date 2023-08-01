using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform arrowTransform;
    public Rigidbody rb;
    public PlayerControl playerControl;
    private bool hasCollided = false; // Flag to track if the arrow has collided

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collsion with" + collision.gameObject.name);
        if (collision.gameObject.name.Contains("Terrain"))
        {
            rb.isKinematic = true;
        }

    }      
    

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.pressTime < 2)
        {
            if (rb.velocity != Vector3.zero)
            {
                // Calculate the rotation angle based on the velocity direction.
                Vector3 velocityDir = rb.velocity.normalized;
                Quaternion targetRotation = Quaternion.LookRotation(velocityDir, Vector3.down);

                // Smoothly rotate the arrow to the target rotation.
                float rotationSpeed = 5f;
                arrowTransform.rotation = Quaternion.Slerp(arrowTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }

    }


}

