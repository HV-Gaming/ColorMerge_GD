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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(Mathf.Round(transform.position.x),transform.position.y, Mathf.Round(transform.position.z));
        //Vector3 targetScale = new Vector3(0.8f, 0.8f, 0.8f);

        if(transform.localScale != new Vector3(0.8f,0.8f,0.8f))
        {
            print("going here...");
            transform.position = new Vector3 (Mathf.Round(transform.position.x*2)/2.0f,transform.position.y,Mathf.Round(transform.position.z*2)/2.0f);
        }
        // When a collision occurs, set the velocity to zero
        // if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shredder" )
        // {

            
            
            

        // }

        
        //
    }
}
