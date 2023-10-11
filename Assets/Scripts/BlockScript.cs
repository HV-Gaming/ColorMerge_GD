using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Rigidbody rb;
    public 

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
        // When a collision occurs, set the velocity to zero
        // if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shredder" )
        // {

            
            
            

        // }

        
        //
    }
}
