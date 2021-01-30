using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    public Animator anim;
    public event Action OnWalk;
    public event Action OnStopWalk;
    public event Action OnSheathShovel;
    public event Action OnWithdrawShovel;
    public event Action OnDeath;
    public event Action OnDig;
    public event Action OnIDLE;

    public bool isTesting = false;
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
        OnWalk += _OnWalk;
        OnStopWalk += _OnStopWalk;
        OnSheathShovel += _OnSheathShovel;
        OnWithdrawShovel += _OnWithdrawShovel;
        OnDeath += _OnDeath;
        OnDig += _OnDig;
        OnIDLE += _OnIDLE;
    }

    private void Update()
    {
        //For test
        if (isTesting)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                OnWalk?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnStopWalk?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnDig?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnWithdrawShovel?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnSheathShovel?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnIDLE?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                OnDeath?.Invoke();
            }
        }
    }

    private void _OnWalk()
    {
        anim.SetBool("IsWalking", true);
    }

    private void _OnStopWalk()
    {
        anim.SetBool("IsWalking", false);
    }

    private void _OnSheathShovel()
    {
        anim.SetTrigger("SheathShovel");
    }

    private void _OnWithdrawShovel()
    {
        anim.SetTrigger("WithdrawShovel");
    }

    private void _OnDeath()
    {
        anim.SetTrigger("Die");
    }

    private void _OnDig()
    {
        anim.SetTrigger("Dig");
    }

    private void _OnIDLE()
    {
        anim.SetBool("IsWalking", false);
    }



}
