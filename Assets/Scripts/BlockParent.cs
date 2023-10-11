using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockParent : MonoBehaviour
{
   public int initialChildCount;
   public GameObject LevelcompleteObject;

    private void Start()
    {
        initialChildCount = transform.childCount;
        LevelcompleteObject.SetActive(false);
        // Get all child GameObjects and add them to the list
        
           
        
    }

    private void Update() 
    {
        checkCompletion();
        
        

        
        
    }

    public void checkCompletion()
    {
        if (transform.childCount == 0)
        {
            // All child objects are destroyed, print "Level Complete" in the console
            LevelcompleteObject.SetActive(true);
        }
    }

    
    
  
}
