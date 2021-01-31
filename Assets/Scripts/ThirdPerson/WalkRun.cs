using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonController))]
public class WalkRun : MonoBehaviour
{
    public bool Walking;
    [SerializeField] private float WalkSpeed = 2.5f;
    private float WalkTurnSpeed = 0.3f;
    [SerializeField] private float RunSpeed = 5.0f;
    private float RunTurnSpeed = 0.05f;

    private Battery Batter_Script;
    private MetalDetector MetalDetector_Script;    
    private ThirdPersonController ThirdPersonController_Script;

    private void Start()
    {
        ThirdPersonController_Script = GetComponent<ThirdPersonController>();
        MetalDetector_Script = gameObject.GetComponentInChildren<MetalDetector>();
        Batter_Script = FindObjectOfType<Battery>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Q) && Batter_Script.BatteryLife > 0)
        {
            Walk();
        }
        else
        {
            Run();
        }
    }
    private void Walk()
    {
        ThirdPersonController_Script.PlayerSpeed = WalkSpeed;
        ThirdPersonController_Script.TurnTime = WalkTurnSpeed;
        MetalDetector_Script.enabled = true;
        Batter_Script.ReduceBatteryLife();
    }
    private void Run()
    {
        ThirdPersonController_Script.PlayerSpeed = RunSpeed;
        ThirdPersonController_Script.TurnTime = RunTurnSpeed;
        MetalDetector_Script.CanPlayFoundAudio = true;
        MetalDetector_Script.enabled = false;
    }
}
