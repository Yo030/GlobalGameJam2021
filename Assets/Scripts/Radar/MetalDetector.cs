using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    [SerializeField] private float DepthDistance;
    [SerializeField] private LayerMask BuriedLayer;
    [SerializeField] private float MetalDetectorRadius;
    [SerializeField] private GameObject[] BuriedObjects;

    /* Start is called before the first frame update
    void Start()
    {
        BuriedObjects = new GameObject[50];
    }*/

    void FixedUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, DepthDistance, BuriedLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * DepthDistance, Color.red);
        }

        FindNearestBuriedObject();
    }

    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, MetalDetectorRadius);
    }

    void FindNearestBuriedObject()
    {
        BuriedObjects = GameObject.FindGameObjectsWithTag("Buried");
        for(int i=0; i<BuriedObjects.Length; i++)
        {
            float distancetoobject = Vector3.Distance(BuriedObjects[i].transform.position, transform.position);
            if(distancetoobject <= MetalDetectorRadius)
            {
                Debug.DrawLine(this.transform.position, BuriedObjects[i].transform.position, Color.blue);
            }
        }
    }
}
