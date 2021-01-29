using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class medidor_fuerza : MonoBehaviour
{
    [Range(6,-6)]
    public Slider slider;
    public float velocidad;
    float pos = 0;

    [Range(3,-3)]
    float valor_bueno = 0;

    // Update is called once per frame
    void Update()
    {
        pos += velocidad * Time.deltaTime;
        slider.value = Mathf.PingPong(pos, slider.maxValue);

        if (Input.GetKeyDown(KeyCode.E))
        {
            slider.value = velocidad * 0;
            velocidad = 0;

            if(valor_bueno==3)
            {
                Debug.Log("es bueno");
            }
        }
        return;
    }
}