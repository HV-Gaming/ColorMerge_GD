using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 targetPos;
    public Rigidbody rb;
    void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        

        
        
    }


    public void Move(Vector3 moveDirection)
    {
         
        rb.velocity = moveDirection.normalized*moveSpeed;
        

    }


}
