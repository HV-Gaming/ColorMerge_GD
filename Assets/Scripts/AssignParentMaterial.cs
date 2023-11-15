using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AssignParentMaterial : MonoBehaviour
{
    void Start()
    {
        // Get the parent GameObject
        Transform parent = transform.parent;

        // Check if there is a parent
        if (parent != null)
        {
            // Get the material of the parent GameObject
            Renderer parentRenderer = parent.GetComponent<Renderer>();

            if (parentRenderer != null)
            {
                // Assign the parent material to the current GameObject
                Renderer currentRenderer = GetComponent<Renderer>();
                currentRenderer.material = parentRenderer.material;
            }
            else
            {
                Debug.LogError("Parent GameObject does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("No parent GameObject found.");
        }
    }
}
