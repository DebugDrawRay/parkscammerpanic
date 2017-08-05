using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AiController : MonoBehaviour 
{
    [Header("Wandering")]
    protected Vector3 homePosition;
    public float wanderRadius;
    public Vector2 timeToWanderRange;

    private float currentWanderTime;

	protected NavMeshAgent agent;

    protected void Initialize()
    {
        homePosition = transform.position;
        currentWanderTime = Random.Range(timeToWanderRange.x, timeToWanderRange.y);
        agent = GetComponent<NavMeshAgent>();
    }

    protected void UpdateWander()
    {
        if(currentWanderTime <= 0)
        {
            Wander();
            currentWanderTime = Random.Range(timeToWanderRange.x, timeToWanderRange.y);
        }
        else
        {
            currentWanderTime -= Time.deltaTime;
        }
    }

    protected void Wander()
    {
        Vector3 pos = homePosition + (Random.insideUnitSphere * wanderRadius);
        pos.y = 0;
        agent.SetDestination(pos);
    }

}
