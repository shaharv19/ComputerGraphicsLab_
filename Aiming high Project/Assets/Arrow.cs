using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;
    private bool hasCollided = false; // Flag to track if the arrow has collided

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("arrow colliding with" + collision.gameObject.name);
        if(collision.gameObject.tag!="Player")
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

    }


}

