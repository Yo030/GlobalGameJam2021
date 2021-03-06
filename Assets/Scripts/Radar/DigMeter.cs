﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class DigMeter : MonoBehaviour
{
    [SerializeField] [Range(0.2f, 4f)] private float BarMoveSpeed = 3f;
    [SerializeField] private HorizontalLayoutGroup Tries_Left_UI;
    [SerializeField] private WeightedProbability WeightedProbability_Script;
    [SerializeField] private ShowHideCursor ShowHideCursor_Script;
    [SerializeField] private GameObject UI_ToDeactivate;
    [SerializeField] private TryController TryController_Script;
    [SerializeField] private Inventory Inventory_Script;
    [Space]
    [SerializeField] private AudioManager AudioManager_Script;
    public string SoundName;

    public GameObject CurrentTresureDiggnig;
    public string CurrentTresureDiggnigName;

    public int Tries = 1;

    private Slider slider;
    private float pos = .5f;
    public int TimesToDig = 1;
    public bool CanMove = true;
    private bool SuccessfulDig;

    private float FillAmountPerSec;
    public float DecreeseSpeedBy;

    [Range(0, 1)] public float[] valor_bueno;

    public float OriginalBarMoveSpeed;

    public Rigidbody PlayerRB;

    private void Awake()
    {
        WeightedProbability_Script = FindObjectOfType<WeightedProbability>();
    }

    private void OnEnable()
    {
        Inventory_Script = FindObjectOfType<Inventory>();
        slider = GetComponent<Slider>();
        DecreeseSpeedBy = (BarMoveSpeed - 0.1f) / 5;
        CanMove = true;
    }

    public void SetDigParameters(GameObject _buriedobject)
    {
        if(OriginalBarMoveSpeed == 0)OriginalBarMoveSpeed = BarMoveSpeed;
        else  BarMoveSpeed = OriginalBarMoveSpeed;

        slider = GetComponent<Slider>();
        slider.value = slider.maxValue / 2;
        CanMove = true;

        CurrentTresureDiggnig = _buriedobject;
        int _id = _buriedobject.GetComponent<SpawnObject>().ObjectID;

        CurrentTresureDiggnigName = VariableManager.instance.Tresures[_id].Name;
        TimesToDig = VariableManager.instance.Tresures[_id].TimesToDig;
        Tries = VariableManager.instance.Tresures[_id].TriesToDig;

        //TryController_Script.CheckForLives(Tries);
    }

    void Update()
    {
        if (CanMove)
        {
            FillAmountPerSec = slider.maxValue / BarMoveSpeed;
            pos += FillAmountPerSec * Time.deltaTime;
            slider.value = Mathf.PingPong(pos, slider.maxValue);

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                StopSlider();
            }
            PlayerRB.isKinematic = false;
        }
        else
        {
            PlayerRB.isKinematic = true;
        }
    }

    private void StopSlider()
    {
        CanMove = false;
        SuccessfulDig = false;

        for(int i=0; i<valor_bueno.Length; i+=2)
        {
            float _value1 = Mathf.Min(valor_bueno[i], valor_bueno[i + 1]);
            float _value2 = Mathf.Max(valor_bueno[i], valor_bueno[i + 1]);

            if (slider.value >= _value1 && slider.value <= _value2)
            {
                SuccessfulDig = true;
            }
        }
        if(SuccessfulDig)
        {
            Debug.Log("Good " + slider.value);
            AudioManager_Script.play(SoundName, 1);
            BarMoveSpeed -= DecreeseSpeedBy;
            TimesToDig--;
        }
        else
        {
            AudioManager_Script.play("Piedra", 1);
            Debug.Log("Bad" + slider.value);
            Tries--;
            //TryController_Script.CheckForLives(Tries);
        }
        Invoke("TryAgain", 0.7f);
    }
    private void TryAgain()
    {
        if(TimesToDig == 0)
        {
            AudioManager_Script.play("Found", 1);
            //Debug.Log("Tresure dug!!!");
            Debug.Log("YOU JUST FOUND A: " + CurrentTresureDiggnigName + "!!!");
            if(CurrentTresureDiggnig != null)
            {
                Inventory_Script.CheckForSpaces(CurrentTresureDiggnig);
            }
            
            CurrentTresureDiggnigName = null;
            Invoke("CanWalkAgain", 1f);
            return;
        }

        if(Tries == 0)
        {
            AudioManager_Script.play("Snap", 1);
            Invoke("CanWalkAgain", 1f);
            Debug.Log("You lost the tresure");
            return;
        }
        CanMove = true;
    }
    private void CanWalkAgain()
    {
        Debug.Log("CanWalkAgain");
        Destroy(CurrentTresureDiggnig);
        ShowHideCursor_Script.EnableDisable(true);
        UI_ToDeactivate.SetActive(false);              //DEACTIVATES DIG UI
    }
}
