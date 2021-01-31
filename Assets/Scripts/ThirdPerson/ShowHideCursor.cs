using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCursor : MonoBehaviour
{
    [SerializeField] private Cinemachine.CinemachineFreeLook CinemachineCamera;
    private ThirdPersonController ThirdPersonController_Script;
    [SerializeField] private WalkRun WalkRun_Script;
    private MetalDetector MetalDetector_Script;

    private void Awake()
    {
        WalkRun_Script = FindObjectOfType<WalkRun>();
        ThirdPersonController_Script = FindObjectOfType<ThirdPersonController>();
        MetalDetector_Script = FindObjectOfType<MetalDetector>();
        Hide();
    }

    public void Hide()
    {
        EnableDisable(true);

        Cursor.visible = false;
        Debug.Log("Cursor is locked: " + Cursor.visible);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Show()
    {
        EnableDisable(false);

        Cursor.visible = true;
        Debug.Log("Cursor is locked: " + Cursor.visible);
        Cursor.lockState = CursorLockMode.None;
    }
    public void EnableDisable(bool _act_deact)
    {
        MetalDetector_Script.enabled = _act_deact;
        ThirdPersonController_Script.CanMove = _act_deact;                                //ACTIVATES PLAYER MOVEMNT
        WalkRun_Script.enabled = _act_deact;                                              //ACTIVATES METAL DETECTOR
        CinemachineCamera.enabled = _act_deact;
    }
}
