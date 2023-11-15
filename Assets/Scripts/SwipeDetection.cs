using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
   
   public BaseMovement player;

   //public BlockParent blockparent;
   private UnityEngine.Vector3 startPos;
   public int pixelDistToDetect = 20;
   private bool fingerDown;
   private bool previousState = false;
   public int swipeCount;
   public int previousSwipeCount = 0;
   //public GameObject GameOverPanel;



    private void Start() {
        //GameOverPanel.SetActive(false);
    }

   private void Update() {

    
    
    

// swipe 
    if(fingerDown == false && Input.GetMouseButtonDown(0))
    {
        startPos = Input.mousePosition;
        fingerDown = true;
    }

    if(fingerDown)
    {
        if(Input.mousePosition.y >= startPos.y + pixelDistToDetect)
        {
           fingerDown = false;
           //Debug.Log("Swipe UP");

           
            player.Move(UnityEngine.Vector3.forward);
          

           
        }
        else if(Input.mousePosition.y <= startPos.y - pixelDistToDetect)
        {
            fingerDown = false;
           //Debug.Log("Swipe Down");

           
            player.Move(UnityEngine.Vector3.back);
            
           

        }

        else if(Input.mousePosition.x >= startPos.x + pixelDistToDetect)
        {
            fingerDown = false;
           //Debug.Log("Swipe Right");
           
            player.Move(UnityEngine.Vector3.right);
            
            

           

           

        }

        else if(Input.mousePosition.x <= startPos.x - pixelDistToDetect)
        {
            fingerDown = false;
           //Debug.Log("Swipe Left");
           

           
            player.Move(UnityEngine.Vector3.left);
            

        }

    }

    if(fingerDown && Input.GetMouseButtonUp(0))
    {
        fingerDown = false;

    }

    





   }
   
   private void LateUpdate()
   {
    CheckSwipe();
   }

   public void CheckSwipe()
   {
    

    if (previousState && !fingerDown)
        {

            if(player.currentCOMint != player.endCOMint)
            {
                swipeCount++;

            }

            
            
        }

        // Update the previous state for the next frame
        previousState = fingerDown;



   }









}
