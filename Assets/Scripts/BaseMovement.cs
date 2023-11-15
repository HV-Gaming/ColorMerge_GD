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
    public Vector3 currentCOM;
    public Vector3 endCOM;
    public Vector3Int endCOMint;
    public Vector3Int currentCOMint;
    
   
    
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
                //Debug.Log(hit.transform.name);
                selection = hit.transform.gameObject;
                currentRb = hit.rigidbody;
                currentCOM = currentRb.worldCenterOfMass;
                currentCOMint = new Vector3Int(Mathf.RoundToInt(currentCOM.x),Mathf.RoundToInt(currentCOM.y),Mathf.RoundToInt(currentCOM.z));
                
               
                

            }
            

        }
        
    }

    public void Move(Vector3 moveDirection)
    {
        if(selection.tag == "LR" && ( moveDirection == UnityEngine.Vector3.left || moveDirection == UnityEngine.Vector3.right ))
        {

            
            currentRb.velocity = Vector3.zero;
            Vector3 movement = moveDirection.normalized * moveSpeed;
        
            currentRb.velocity = movement;
            //print(movement);

        movestop();


        }

        if(selection.tag == "UD" && ( moveDirection == UnityEngine.Vector3.forward || moveDirection == UnityEngine.Vector3.back ))
        {

            
            currentRb.velocity = Vector3.zero;
            Vector3 movement = moveDirection.normalized * moveSpeed;
        
            currentRb.velocity = movement;
            //print(movement);

        movestop();


        }
        
        

       
        

    }

    public void movestop()
    {
        

        if(currentRb.velocity  == Vector3.zero)
        {
            endCOM = currentRb.worldCenterOfMass;
            endCOMint = new Vector3Int(Mathf.RoundToInt(endCOM.x),Mathf.RoundToInt(endCOM.y),Mathf.RoundToInt(endCOM.z));
            

            

        }
    }


    

    
}
