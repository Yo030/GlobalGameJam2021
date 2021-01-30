using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class WalkingAIController : MonoBehaviour
{
    public event Action OnStartWalking;
    public event Action OnEndWalking;
    public event Action OnStartTalking;
    public event Action OnEndTalking;
    public event Action OnStartLayingdown;
    public event Action OnEndLayingdown;
    public event Action OnStartGettingUp;
    public event Action OnEndGettingUp;

    public NavMeshAgent mNavMeshAgent;
    public AIZone currentAIZone;

    public List<AIZone> zonas = new List<AIZone>();
    public bool has_destiny = false;
    public bool reach_destiny = false;
    private void Awake()
    {
        mNavMeshAgent = this.GetComponent<NavMeshAgent>();
        
    }

    private void OnEnable()
    {
        OnEndTalking += onEndTalking;
        OnEndLayingdown += onEndStandingUp;
    }

    private void FixedUpdate()
    {
        if (!mNavMeshAgent.pathPending && has_destiny && !reach_destiny)
        {
            if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
            {
                if (!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    has_destiny = false;
                    reach_destiny = true;
                    OnEndWalking?.Invoke();
                    if(currentAIZone.zone_type == AI_ZONE.LAYING_DOWN)
                    {
                        OnStartLayingdown?.Invoke();
                        StartCoroutine(LaydownCoroutine());
                    }
                    else if (currentAIZone.zone_type == AI_ZONE.TALKING)
                    {
                        OnStartTalking?.Invoke();
                        StartCoroutine(TalkCoroutine());
                    }
                }
            }
        }
    }

    private void Update()
    {
        //TESTING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToZone(zonas[UnityEngine.Random.Range(0, zonas.Count)]);
        }
    }

    public void GoToZone(AIZone zone)
    {
        if (zone.max_amount > zone.on_or_going_to && zone != currentAIZone)
        {
            mNavMeshAgent.SetDestination(zone.transform.position);
            currentAIZone = zone;
            zone.on_or_going_to += 1;
            OnStartWalking?.Invoke();
            has_destiny = true;
            reach_destiny = false;
            return;
        }
        for (int i = 0; i < 15; i++)
        {
            AIZone _zone = zonas[UnityEngine.Random.Range(0, zonas.Count)];
            if(currentAIZone != _zone && _zone.max_amount > _zone.on_or_going_to)
            {
                currentAIZone = _zone;
                break;
            }
        }
        if (currentAIZone.max_amount > currentAIZone.on_or_going_to)
        {
            mNavMeshAgent.SetDestination(zone.transform.position);
            zone.on_or_going_to += 1;
            OnStartWalking?.Invoke();
            has_destiny = true;
            reach_destiny = false;
            return;
        }
    }

    IEnumerator LaydownCoroutine()
    {
        float timer = UnityEngine.Random.Range(10,20);
        while(timer > 0)
        {
            yield return new WaitForFixedUpdate();
            timer -= Time.fixedDeltaTime;
        }
        OnEndLayingdown?.Invoke();
    }

    IEnumerator TalkCoroutine()
    {
        float timer = UnityEngine.Random.Range(10, 20);
        while (timer > 0)
        {
            yield return new WaitForFixedUpdate();
            timer -= Time.fixedDeltaTime;
        }
        OnEndTalking?.Invoke();
    }

    public void onEndTalking()
    {
        currentAIZone.on_or_going_to -= 1;
        GoToZone(zonas[UnityEngine.Random.Range(0, zonas.Count)]);
    }

    public void onEndStandingUp()
    {
        currentAIZone.on_or_going_to -= 1;
        GoToZone(zonas[UnityEngine.Random.Range(0, zonas.Count)]);
    }
}


public enum AI_STATES
{
    WALKING,
    TALKING,
    LAYING_DOWN,
    GETTING_UP,
}

public enum AI_ZONE
{
    TALKING,
    LAYING_DOWN,
}