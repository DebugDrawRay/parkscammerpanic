using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiController : MonoBehaviour 
{
    [Header("Wandering")]
    protected Vector3 homePosition;
    public float wanderRadius;
    public Vector2 timeToWanderRange;

    [Header("Patroling")]
    public Transform[] patrolPoints;
    private Vector3 currentDestination;
    private bool patrolDestinationSet;
    private float patrolPauseCountdown = 0;

    private float currentWanderTime;

	protected NavMeshAgent agent;

    protected void Initialize()
    {
        homePosition = transform.position;
        currentWanderTime = Random.Range(timeToWanderRange.x, timeToWanderRange.y);
        currentDestination = GetRandomPatrolPoint();
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

    protected void UpdatePatrol()
    {
        if (patrolPoints.Length > 0)
        {
            if (patrolDestinationSet)
            {
                if (Vector3.Distance(transform.position, currentDestination) < 0.5f)
                {
                    patrolDestinationSet = false;
                    patrolPauseCountdown = 2f;
                }
            }
            else
            {
                if (patrolPauseCountdown <= 0)
                {
                    currentDestination = GetRandomPatrolPoint();
                    agent.SetDestination(currentDestination);
                    patrolDestinationSet = true;
                }
                else
                {
                    patrolPauseCountdown -= Time.deltaTime;
                }
            }
        }
        else
        {
            UpdateWander();
        }
    }

    private Vector3 GetRandomPatrolPoint()
    {
        Vector3 patrolPoint = Vector3.zero;
        if (patrolPoints.Length > 0)
        {
            int patrolIndex = Random.Range(0, patrolPoints.Length);
            patrolPoint = patrolPoints[patrolIndex].position;
            patrolPoint.y = transform.position.y;
        }

        return patrolPoint;
    }
}
