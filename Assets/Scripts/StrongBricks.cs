using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBricks : MonoBehaviour
{
    public GameObject brickParticle;

    public Material material;
    private Renderer rend; 
    private int BrickLife = 2;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter()
    {
        if (BrickLife == 1)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM.instance.DestroyBrick();
            Destroy(gameObject);
        }
        else
        {
            rend.sharedMaterial = material;
            BrickLife--;

        }
    }
}
