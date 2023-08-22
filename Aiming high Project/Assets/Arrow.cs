using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Text enemyHit;
    public Transform arrowTransform;
    public Rigidbody rb;
    public PlayerControl playerControl;
    private bool hasCollided = false; // Flag to track if the arrow has collided
    public bool collisionWithTarget;
    [SerializeField] GameManagment gameManagment;
    [SerializeField] enemyErrorCollsion enemyErrorCollsion;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Arrow collision with: " + collision.gameObject.name);
        if(collision.gameObject.tag.Contains("target"))
        {
            gameManagment.collisionWithTarget = true;
            string numbersOnly = Regex.Replace(collision.gameObject.name, "[^0-9]", "");
            if (int.Parse(numbersOnly)==gameManagment.currentTarget+1)
            {
                gameManagment.isCurrentTarget = true;
            }


        }
        if (collision.gameObject.name.Contains("enemy"))
        {
            enemyErrorCollsion.scoreTxt.text = (int.Parse(enemyErrorCollsion.scoreTxt.text) + 20).ToString();
            enemyHit.enabled = true;
            Destroy(gameObject);
            StartCoroutine(HideMessageAfterDelay());
        }

        if (collision.gameObject.name.Contains("Terrain")||collision.gameObject.tag.Contains("target"))
        {
            rb.isKinematic = true;
        }

        if (collision.gameObject.tag.Contains("wall") || collision.gameObject.tag.Contains("cube"))
        {
            rb.isKinematic = true;
        }

    }


    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        enemyHit.enabled = false; // Hide the message
    }



    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, 10);
        enemyHit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if (playerControl.pressTime < 2)
    //    {
            if (rb.velocity != Vector3.zero)
            {
                // Calculate the rotation angle based on the velocity direction.
                Vector3 velocityDir = rb.velocity.normalized;
                Quaternion targetRotation = Quaternion.LookRotation(velocityDir, Vector3.down);

                // Smoothly rotate the arrow to the target rotation.
                float rotationSpeed = 20f;
                arrowTransform.rotation = Quaternion.Slerp(arrowTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
      //  }

    }


}

