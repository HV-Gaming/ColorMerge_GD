using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    public MeshRenderer selfMeshRenderer;
    public ParticleSystem ps;
    public ParticleSystemRenderer psr;
    // Start is called before the first frame update
    void Start()
    {
        selfMeshRenderer = GetComponent<MeshRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        psr = GetComponentInChildren<ParticleSystemRenderer>();
        psr.material = selfMeshRenderer.sharedMaterial;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "LR" || collision.gameObject.tag =="UD")
        {
            //Debug.Log("Detected Player");
            MeshRenderer collidedRenderer = collision.collider.GetComponent<MeshRenderer>();

        // Check if the materials match
        if (collidedRenderer.sharedMaterial.color == selfMeshRenderer.sharedMaterial.color)
        {
            //Debug.Log("same material");
            ps.Play();
            // Destroy the GameObject if the materials match
            Destroy(collision.gameObject,0.05f);

        }

        }
        // Get the material of the collided object
        
    }
}
