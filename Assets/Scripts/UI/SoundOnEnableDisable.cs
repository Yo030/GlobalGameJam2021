using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnEnableDisable : MonoBehaviour
{
    //[SerializeField] private GameObject AudioManager_GameObject;
    [SerializeField] private AudioManager AudioManager_Script;
    public string SoundName;

    private void Start()
    {
    }

    private void OnEnable()
    {
        AudioManager_Script.play(SoundName, 1);
    }

    private void OnDisable()
    {
        AudioManager_Script.play(SoundName, 1);
    }
}
