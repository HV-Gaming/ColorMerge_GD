using UnityEngine;
using System.Collections.Generic;

public class ChildMovementTracker : MonoBehaviour
{
    [SerializeField]
    private int moveCounter = 0;

    [SerializeField]
    private List<Transform> childTransforms;

    [SerializeField]
    private List<Vector3Int> initialChildPositions;

    [SerializeField]
    private List<Vector3> lastChildVelocities;

    private void Start()
    {
        // Initialize lists to track child GameObjects, their initial positions, and velocities.
        childTransforms = new List<Transform>();
        initialChildPositions = new List<Vector3Int>();
        lastChildVelocities = new List<Vector3>();

        // Populate the initial lists with child GameObjects and their positions.
        foreach (Transform child in transform)
        {
            childTransforms.Add(child);
            initialChildPositions.Add(Vector3Int.RoundToInt(child.position));
            lastChildVelocities.Add(Vector3.zero);
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
                lastChildVelocities.RemoveAt(i);
            }
            else
            {
                // Check if the child's velocity has become 0.
                Vector3 currentVelocity = (childTransforms[i].position - initialChildPositions[i]) / Time.deltaTime;
                if (currentVelocity == Vector3.zero && currentVelocity == lastChildVelocities[i])
                {
                    // Child's velocity is 0 and hasn't changed, so consider it a position change.
                    moveCounter--;
                }
                lastChildVelocities[i] = currentVelocity;
            }
        }
    }
}
