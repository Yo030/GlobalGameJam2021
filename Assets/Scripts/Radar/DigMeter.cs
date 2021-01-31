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

    public GameObject CurrentTresureDiggnig;
    public string CurrentTresureDiggnigName;

    public int Tries = 1;

    private Slider slider;
    private float pos = .5f;
    public int TimesToDig = 1;
    private bool CanMove = true;
    private bool SuccessfulDig;

    private float FillAmountPerSec;
    public float DecreeseSpeedBy;

    [Range(0, 1)] public float[] valor_bueno;

    private void Awake()
    {
        WeightedProbability_Script = FindObjectOfType<WeightedProbability>();
    }

    private void Start()
    {
        Inventory_Script = FindObjectOfType<Inventory>();
        slider = GetComponent<Slider>();
        DecreeseSpeedBy = (BarMoveSpeed - 0.1f) / 5;
    }

    public void SetDigParameters(GameObject _buriedobject)
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue / 2;
        CanMove = true;

        CurrentTresureDiggnig = _buriedobject;
        int _id = _buriedobject.GetComponent<SpawnObject>().ObjectID;

        CurrentTresureDiggnigName = WeightedProbability_Script.Tresures[_id].Name;
        TimesToDig = WeightedProbability_Script.Tresures[_id].TimesToDig;
        Tries = WeightedProbability_Script.Tresures[_id].TriesToDig;

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
            //Debug.Log("Good " + slider.value);
            BarMoveSpeed -= DecreeseSpeedBy;
            TimesToDig--;
        }
        else
        {
            //Debug.Log("Bad" + slider.value);
            Tries--;
            //TryController_Script.CheckForLives(Tries);
        }
        Invoke("TryAgain", 2f);
    }
    private void TryAgain()
    {
        if(TimesToDig == 0)
        {
            //Debug.Log("Tresure dug!!!");
            Debug.Log("YOU JUST FOUND A: " + CurrentTresureDiggnigName + "!!!");
            Inventory_Script.CheckForSpaces(CurrentTresureDiggnig, 3);
            CurrentTresureDiggnigName = null;
            Invoke("CanWalkAgain", 1f);
            Destroy(CurrentTresureDiggnig);
            return;
        }

        if(Tries == 0)
        {
            Debug.Log("Loser");
            return;
        }
        CanMove = true;
    }
    private void CanWalkAgain()
    {
        ShowHideCursor_Script.Hide();                   //SHOWS CURSOR
        UI_ToDeactivate.SetActive(false);              //ACTIVATES DIG UI
    }
}
