using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BaseMovement : MonoBehaviour
{

    //[SerializeField] private Transform emptySpace;
    private Camera _camera;
    public GameObject selection;

    public SwipeDetection swipedetector;

    //public Player player;
    public Rigidbody currentRb;
    public float moveSpeed = 10f;
    
   
    
    void Start()
    {
        _camera = Camera.main;
        
        
        
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.transform.name);
                selection = hit.transform.gameObject;
                currentRb = hit.rigidbody;
                
               
                

            }
            

        }
        
    }

    public void Move(Vector3 moveDirection)
    {
        
        currentRb.velocity = Vector3.zero;
        Vector3 movement = moveDirection.normalized * moveSpeed;
        
        currentRb.velocity = movement;
        print(movement);

       
        

    }


    

    
}
