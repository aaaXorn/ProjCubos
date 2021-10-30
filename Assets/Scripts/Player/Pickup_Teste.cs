using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Teste : MonoBehaviour
{

    [SerializeField]
    bool grabInput;

    RaycastHit rayHit;
    
    [SerializeField]
    float raycastDist, hitDist;

    [SerializeField]
    string layerMask;
    int groundLayer;

    
    // Start is called before the first frame update
    void Start()
    {
        groundLayer = LayerMask.GetMask(layerMask);
    }

    // Update is called once per frame
    void Update()
    {
        grabInput = Input.GetButton("Interact");
        Debug.Log(grabInput);

        if (grabInput)
        {
           
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit, raycastDist, groundLayer))
            {
                hitDist = Vector3.Distance(transform.position, rayHit.point);

                if (hitDist < 2)
                {

                }
                   else
                {

                }            
            }
        } 
            
    }

    void FixedUpdate()
    {

    }

}
