using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
   
   public BaseMovement player;
   private UnityEngine.Vector3 startPos;
   public int pixelDistToDetect = 20;
   private bool fingerDown;
   public int swipeCount;
   public int previousSwipeCount = 0;
   //public GameObject GameOverPanel;



    private void Start() {
        //GameOverPanel.SetActive(false);
    }

   private void Update() {

    checkmoves();
    
    

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
           Debug.Log("Swipe UP");

           
            player.Move(UnityEngine.Vector3.forward);
          

           
        }
        else if(Input.mousePosition.y <= startPos.y - pixelDistToDetect)
        {
            fingerDown = false;
           Debug.Log("Swipe Down");

           
            player.Move(UnityEngine.Vector3.back);
            
           

        }

        else if(Input.mousePosition.x >= startPos.x + pixelDistToDetect)
        {
            fingerDown = false;
           Debug.Log("Swipe Right");
           
            player.Move(UnityEngine.Vector3.right);
            
            

           

           

        }

        else if(Input.mousePosition.x <= startPos.x - pixelDistToDetect)
        {
            fingerDown = false;
           Debug.Log("Swipe Left");
           

           
            player.Move(UnityEngine.Vector3.left);
            

        }

    }

    if(fingerDown && Input.GetMouseButtonUp(0))
    {
        fingerDown = false;

    }






    ////////////////////////////////////experiment

    if (Input.GetMouseButtonUp(0))
    {
        UnityEngine.Vector3 endPos = Input.mousePosition;
        UnityEngine.Vector3 swipeVector = endPos - startPos;

        // Calculate the magnitude (length) of the swipeVector
        float swipeMagnitude = swipeVector.magnitude;

        // Check if the swipe magnitude is greater than the threshold
        if (swipeMagnitude >= pixelDistToDetect)
        {
            // Determine the direction of the swipe
            swipeVector.Normalize();
            float angle = Mathf.Atan2(swipeVector.y, swipeVector.x) * Mathf.Rad2Deg;

            if (angle > -45f && angle <= 45f)
            {
                // Right swipe
                Debug.Log("Swipe Right");
            }
            else if (angle > 45f && angle <= 135f)
            {
                // Up swipe
                Debug.Log("Swipe Up");
            }
            else if (angle > -135f && angle <= -45f)
            {
                // Down swipe
                Debug.Log("Swipe Down");
            }
            else
            {
                // Left swipe
                Debug.Log("Swipe Left");
            }

            // Increment the swipe count
            swipeCount++;
            Debug.Log("Total Swipes: " + swipeCount);
        }
    }






    ////////////////////////////////

   }

   public void checkmoves()
   {
    // if(Moves <= 0)
    // {
    //     Debug.Log("Game Over");
    //     GameOverPanel.SetActive(true);
    // }
   }









}
