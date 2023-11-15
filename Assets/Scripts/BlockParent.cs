using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockParent : MonoBehaviour
{
   public int initialChildCount;
   public int currentChildCount;

   public int newChildCount;
   
   public GameObject LevelcompleteObject;
   public GameObject GameCam;

   public SwipeDetection swipeDetection;

    private void Start()
    {
        initialChildCount = transform.childCount;
        LevelcompleteObject.SetActive(false);
        currentChildCount = initialChildCount;
        // Get all child GameObjects and add them to the list
        
           
        
    }

    public void Update() 
    {
        checkCompletion();
        
        
        checkchildCount();
        
        
        

        
        
    }

    public void checkchildCount()
    {
        newChildCount = transform.childCount;
        
        if(newChildCount<currentChildCount)
        {
            
            print("one child destroyed");
            swipeDetection.swipeCount+=1;
            
            resetcheck();
            
        }

        


    }
    public void resetcheck()
    {
        currentChildCount = newChildCount;
        

    }

    public void checkCompletion()
    {
        if (transform.childCount == 0)
        {
            // All child objects are destroyed, print "Level Complete" in the console
            LevelcompleteObject.SetActive(true);
            GameCam.SetActive(false);
        }
    }

    
    
  
}
