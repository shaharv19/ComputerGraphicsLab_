using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("wall with" + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("wall in" + other.gameObject.name);
    }
}
