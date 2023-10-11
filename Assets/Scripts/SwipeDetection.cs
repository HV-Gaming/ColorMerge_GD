using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
   
   public BaseMovement player;
   private UnityEngine.Vector2 startPos;
   public int pixelDistToDetect = 20;
   private bool fingerDown;
   public int Moves = 10;
   public GameObject GameOverPanel;



    private void Start() {
        GameOverPanel.SetActive(false);
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

   }

   public void checkmoves()
   {
    if(Moves <= 0)
    {
        Debug.Log("Game Over");
        GameOverPanel.SetActive(true);
    }
   }









}
