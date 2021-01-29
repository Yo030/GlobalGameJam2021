using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZone : MonoBehaviour
{
    [Range(0, 5)]
    public int max_amount = 1;
    public AI_ZONE zone_type = AI_ZONE.TALKING;
    public int on_or_going_to = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
