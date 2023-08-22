using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyErrorCollsion : MonoBehaviour
{
    public Text scoreTxt;
    private bool hasCollided = false;
    public Text hitText;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        hitText.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            if (collision.gameObject.tag.Contains("Player"))
            {
                hitText.enabled = true;
                hasCollided = true;
                int score = int.Parse(scoreTxt.text) - 20;
                scoreTxt.text = score.ToString();
                Destroy(gameObject);
                StartCoroutine(HideMessageAfterDelay());
            }

            if (collision.gameObject.tag.Contains("wall"))
            {
                    rb.isKinematic = true;
                
            }
        }

    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        hitText.enabled = false; // Hide the message
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
