using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class ChildMovementTracker : MonoBehaviour
{
    [SerializeField]
    private int moveCounter = 0;

    [SerializeField]
    private List<Transform> childTransforms;

    [SerializeField]
    private List<Vector3Int> initialChildPositions;

    
    


    public SwipeDetection sd;
    public List<Vector3Int> finalChildPositions = new List<Vector3Int>();
    public List<Rigidbody> childRigidbodies = new List<Rigidbody>();

    private void Start()
    {
        // Initialize lists to track child GameObjects, their initial positions, and velocities.
        childTransforms = new List<Transform>();
        initialChildPositions = new List<Vector3Int>();
        

        // Populate the initial lists with child GameObjects and their positions.
        foreach (Transform child in transform)
        {
            childTransforms.Add(child);
            initialChildPositions.Add(Vector3Int.RoundToInt(child.position));
            

            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                childRigidbodies.Add(rb);
            }
        }
    }

    private void Update()
    {


        
        // Check for destroyed child GameObjects and update moveCounter accordingly.
        for (int i = childTransforms.Count - 1; i >= 0; i--)
        {
            if (childTransforms[i] == null)
            {
                // Child GameObject was destroyed, so reduce the moveCounter.
                moveCounter--;
                childTransforms.RemoveAt(i);
                initialChildPositions.RemoveAt(i);
                
            }
           

            

            /////////////////////////////////////////////////////////

            Vector3Int currentIntPosition = Vector3Int.RoundToInt(childTransforms[i].position);

            if (childRigidbodies[i] != null && childRigidbodies[i].velocity.magnitude < 0.01f)
            {
                // The child at index i has stopped moving
                //Debug.Log("Child " + i + " has reached its final destination at " + currentIntPosition);
                // Optionally, you can remove this child from monitoring
                // childRigidbodies[i] = null;
            }

            // Update the initial position to the current position for future comparisons
            initialChildPositions[i] = currentIntPosition;

            ////////////////////////////////////////////////////////
        }

        if(sd.swipeCount != sd.previousSwipeCount)
        {





            print("swiped");

            sd.previousSwipeCount = sd.swipeCount;


        }

        






        checkMoves();

    }

    public void checkMoves()
    {
        



    }

    
}



