using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(WalkingAIController))]
[RequireComponent(typeof(Animator))]
public class WalkingAIAnimatorController : MonoBehaviour
{
    [HideInInspector] public Animator Anim;
    [HideInInspector] public WalkingAIController AIC;

    private void OnEnable()
    {
        AIC = this.GetComponent<WalkingAIController>();
        Anim = this.GetComponent<Animator>();

        AIC.OnStartWalking += startWalking;
        AIC.OnEndWalking += endWalking;
        AIC.OnStartLayingdown += startLayingDown;
        AIC.OnEndLayingdown += endLayingDown;
        AIC.OnEndGettingUp += endStandingUp;
        AIC.OnStartTalking += startTalking;
        AIC.OnEndTalking += endTalking;
    }

    public void startWalking()
    {
        if(Anim.GetCurrentAnimatorStateInfo(0).IsName("NEUTRAL"))
        {
            Anim.SetTrigger("WALK");
        }
        else
        {
            Anim.SetTrigger("NEUTRAL");
            Anim.SetTrigger("WALK");
        }
    }

    public void endWalking()
    {
        
    }

    public void startLayingDown()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("NEUTRAL"))
        {
            Anim.SetTrigger("LAYDOWN");
        }
        else
        {
            Anim.SetTrigger("NEUTRAL");
            Anim.SetTrigger("LAYDOWN");
        }
    }

    public void endLayingDown()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("NEUTRAL"))
        {
            Anim.SetTrigger("STANDUP");
        }
        else
        {
            Anim.SetTrigger("NEUTRAL");
            Anim.SetTrigger("STANDUP");
        }
    }

    public void endStandingUp()
    {
        Anim.SetTrigger("NEUTRAL");
    }

    public void startTalking()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("NEUTRAL"))
        {
            Anim.SetTrigger("TALK");
        }
        else
        {
            Anim.SetTrigger("NEUTRAL");
            Anim.SetTrigger("TALK");
        }
    }

    public void endTalking()
    {
        Anim.SetTrigger("NEUTRAL");
    }
}


