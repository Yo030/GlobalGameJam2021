﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    [SerializeField] private float DepthDistance;
    [SerializeField] private LayerMask BuriedLayer;
    [SerializeField] private float MetalDetectorRadius;
    [SerializeField] private int DivideCircleIn = 5; //2.5 with metal detecter 5 normal
    [SerializeField] private GameObject[] BuriedObjects;
    private GameObject ParentGameObject;
    [SerializeField] private GameObject AudioManager_GameObject;
    private AudioSource AudioSource_Component;
    private AudioManager AudioManager_Script;

    [SerializeField] private bool OnTopOfTresure;
    private bool CanPlayFoundAudio = true;

    [SerializeField] private Dig DigScript;
    //private bool CanDig;
    [SerializeField] private GameObject BuriedObjectBeneath;

    private void Start()
    {
        ParentGameObject = gameObject.transform.parent.gameObject;
        AudioSource_Component = AudioManager_GameObject.GetComponent<AudioSource>();
        AudioManager_Script = AudioManager_GameObject.GetComponent<AudioManager>();
        DigScript = FindObjectOfType<Dig>();
    }
    
    private void Update()
    {
        if(BuriedObjectBeneath != null)
        {
            //DigScript.ShowDigUI(true);

            if (Input.GetKeyUp(KeyCode.E))
            {
                DigScript.DiscoverTresure(BuriedObjectBeneath);
            }
        }
        else
        {
            //DigScript.ShowDigUI(false);
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down), out hit, DepthDistance, BuriedLayer))
        {
            Debug.DrawRay(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            OnTopOfTresure = true;
            BuriedObjectBeneath = hit.transform.gameObject;
            //CanDig = true;
        }
        else
        {
            Debug.DrawRay(ParentGameObject.transform.position, transform.TransformDirection(Vector3.down) * DepthDistance, Color.red);
            if(OnTopOfTresure)
            {
                CanPlayFoundAudio = true;
                OnTopOfTresure = false;
                BuriedObjectBeneath = null;
                //CanDig = false;
            }
        }


        FindNearestBuriedObject();
    }

    private void OnDrawGizmos()
    {
        float _devidedradius = MetalDetectorRadius / DivideCircleIn;
        Gizmos.color = new Color(50, 100, 10, .2f);
        for(int i=0; i< DivideCircleIn; i++)
        {
            Gizmos.DrawSphere(transform.position, _devidedradius * i);
        }
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
        float _devidedradius = MetalDetectorRadius / DivideCircleIn;
        
        if(OnTopOfTresure)
        {
            PlayAudio("Beet", 4.5f);
            if (CanPlayFoundAudio)
            {
                AudioManager_Script.play("Correct_Beep", 1f);
                CanPlayFoundAudio = false;
            }
        }
        else if (_distncetoobject <= _devidedradius)
        {
            //Debug.Log("Bueried Obj is LESS then 1/5 Away");
            PlayAudio("Beet", 3f);
        }
        else if (_distncetoobject <= _devidedradius * 2)
        {
            //Debug.Log("Bueried Obj is LESS then 2/5 Away");
            PlayAudio("Beet", 2.5f);
        }
        else if (_distncetoobject <= _devidedradius * 3)
        {
            //Debug.Log("Bueried Obj is LESS then 3/5 Away");
            PlayAudio("Beet", 2f);
        }
        else if (_distncetoobject <= _devidedradius * 4)
        {
            //Debug.Log("Bueried Obj is LESS then 4/5 Away");
            PlayAudio("Beet", 1.5f);
        }
        else
        {
            //Debug.Log("Bueried Obj is MORE than 4/5 Away");
            PlayAudio("Beet", 1f);
        }
    }

    private void PlayAudio(string _soundname, float _pitch)
    {
        if(!AudioSource_Component.isPlaying)
        {
            AudioManager_Script.play(_soundname, _pitch);
        }
    }
}
