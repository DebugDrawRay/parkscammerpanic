using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : AiController
{
    private CharacterController player
    {
        get
        {
            return CharacterController.Instance;
        }
    }

    public enum State
    {
        None,
        Idle,
        Patrol,
        Chase
    }

    public float moneyToTake;

    public delegate void Reset();
    public static Reset ResetAll;

    private State previousState = State.None;
    private State _currentState;
    private State currentState
    {
        get { return _currentState; }
        set
        {
            previousState = _currentState;
            _currentState = value;
        }
    }

    private void OnEnable()
    {
        GameManager.GameStateChanged += OnGameStateChanged;
        ResetAll += ResetPolice;
    }
    private void OnDisable()
    {
        GameManager.GameStateChanged -= OnGameStateChanged;
        ResetAll -= ResetPolice;
    }
    private void OnDestroy()
    {
        ResetAll -= ResetPolice;
    }
    private void Awake()
    {
        patrolPoints = SpawnManager.Instance.GetPolicePatrolPoints();
    }
    private void Start()
    {
        Initialize();
    }
    public void Aggravate()
    {
        currentState = State.Chase;
    }
    private void Update()
    {
        RunStates();
    }
    private void RunStates()
    {
        switch (currentState)
        {
            case State.Patrol:
                UpdatePatrol();
                break;
            case State.Chase:
                ChasePlayer();
                break;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
    public void ResetPolice()
    {
        SpawnManager.Instance.RemovedPolice();
        Destroy(gameObject);
    }
    private void OnGameStateChanged(GameState gameState)
    {
        Debug.Log("Police : State Change");
        switch (gameState)
        {
            case GameState.Paused:
                currentState = State.Idle;
                break;
            case GameState.Playing:
                currentState = previousState == State.None ? State.Patrol : previousState;
                break;
            default:
                currentState = State.Idle;
                break;
        }
    }
}
