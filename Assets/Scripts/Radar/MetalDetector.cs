using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    [SerializeField] private float DepthDistance;
    [SerializeField] private LayerMask BuriedLayer;
    [SerializeField] private float MetalDetectorRadius;
    [SerializeField] private GameObject[] BuriedObjects;
    private GameObject ParentGameObject;

    private void Start()
    {
        ParentGameObject = gameObject.transform.parent.gameObject;
    }

    void FixedUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down), out hit, DepthDistance, BuriedLayer))
        {
            Debug.DrawRay(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down) * DepthDistance, Color.red);
        }

        FindNearestBuriedObject();
    }

    private void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(50, 100, 10, .5f);
        Gizmos.DrawSphere(transform.position, MetalDetectorRadius);
    }

    private void FindNearestBuriedObject()
    {
        BuriedObjects = GameObject.FindGameObjectsWithTag("Buried");
        for(int i=0; i<BuriedObjects.Length; i++)
        {
            float distancetoobject = Vector3.Distance(BuriedObjects[i].transform.position, transform.position);
            if(distancetoobject <= MetalDetectorRadius)
            {
                Debug.DrawLine(this.transform.position, BuriedObjects[i].transform.position, Color.blue);
                FoundObject(distancetoobject);
            }
        }
    }

    private void FoundObject(float _distncetoobject)
    {
        float _devidedradius = MetalDetectorRadius / 5;

        if (_distncetoobject <= _devidedradius)
        {
            Debug.Log("Bueried Obj is LESS then 1/5 Away");
        }
        else if (_distncetoobject <= _devidedradius * 2)
        {
            Debug.Log("Bueried Obj is LESS then 2/5 Away");
        }
        else if (_distncetoobject <= _devidedradius * 3)
        {
            Debug.Log("Bueried Obj is LESS then 3/5 Away");
        }
        else if (_distncetoobject <= _devidedradius * 4)
        {
            Debug.Log("Bueried Obj is LESS then 4/5 Away");
        }
        else
        {
            Debug.Log("Bueried Obj is MORE than 4/5 Away");
        }

        /*
        else if (_distncetoobject <= _devidedradius && _distncetoobject > _devidedradius * 3)
        {

        }*/
    }

}
