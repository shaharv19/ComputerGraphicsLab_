using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObj : MonoBehaviour
{
    public Rigidbody rb;
    public Collision c1;
    public Collision c2;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(other.tag=="cube" || other.tag=="wall")
        {
            Debug.Log("collide");
        }
    }
}
