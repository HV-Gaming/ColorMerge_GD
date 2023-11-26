using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) != 5f && Mathf.Abs(rb.velocity.z) != 5f)
        {
            // If not, set the velocity of the Rigidbody to zero
            rb.velocity = Vector3.zero;
        }

        if (gameObject.CompareTag("LR"))
        {
            // If the tag is "LR", allow movement only in the X axis
            rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);
        }
        if (gameObject.CompareTag("UD"))
        {
            // If the tag is "UD", allow movement only in the Z axis
            rb.velocity = new Vector3(0f, 0f, rb.velocity.z);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.transform.position = new Vector3(Mathf.Round(transform.position.x),transform.position.y, Mathf.Round(transform.position.z));
        //Vector3 targetScale = new Vector3(0.8f, 0.8f, 0.8f);

        // if(transform.localScale != new Vector3(0.8f,0.8f,0.8f))
        // {
        //     print("going here...");
        //     transform.position = new Vector3 (Mathf.Round(transform.position.x*2)/2.0f,transform.position.y,Mathf.Round(transform.position.z*2)/2.0f);
        // }
        // When a collision occurs, set the velocity to zero
        if(collision.gameObject.tag == "LR" || collision.gameObject.tag == "UD" )
        {
            rb.velocity = Vector3.zero;

            Vector3 roundedPosition = new Vector3(
                Mathf.Round(transform.position.x * 2) / 2,
                transform.position.y,
                Mathf.Round(transform.position.z * 2) / 2);
            
            transform.position = roundedPosition;

            
            
            

        }



        
        //
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the colliding GameObject has the tag "LR" or "UD"
        if (collision.gameObject.CompareTag("LR") || collision.gameObject.CompareTag("UD") || collision.gameObject.CompareTag("Shredder"))
        {
            // Reset the position of this GameObject to its previous position
            transform.position = transform.position;
        }
    }
}
