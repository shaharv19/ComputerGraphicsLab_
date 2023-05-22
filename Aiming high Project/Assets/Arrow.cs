using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

   public void OnCollisionEnter(Collision collision)
    {
       // if (collision.gameObject.tag == "character (3)")
        //{
         //   Debug.Log("here");
         
         Physics.IgnoreCollision(rb.GetComponent<Collider>(),GetComponent<Collider>(),true);

         Debug.Log("hello");

        // }
        Debug.Log("coliision with arrow" + collision.gameObject.name);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("coliision with arrow" + collision.gameObject.name);
    }
    void Update()
    {
       
    }
}
