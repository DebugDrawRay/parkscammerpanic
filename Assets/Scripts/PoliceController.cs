using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

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

    public int moneyToTake;

    public delegate void Reset();
    public static Reset ResetAll;
    public static Reset Open;

    public SkinnedMeshRenderer render;
    public float leaveAnimTime;
    public Ease leaveEase;

    public GameObject chaseLight;

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
        Open += OpenDrawer;
    }
    private void OnDisable()
    {
        GameManager.GameStateChanged -= OnGameStateChanged;
        ResetAll -= ResetPolice;
        Open -= OpenDrawer;
    }
    private void OnDestroy()
    {
        ResetAll -= ResetPolice;
        Open -= OpenDrawer;
    }
    private void Awake()
    {
        patrolPoints = SpawnManager.Instance.GetPolicePatrolPoints();
        chaseLight.SetActive(false);
    }
    private void Start()
    {
        Initialize();
    }
    public void Aggravate()
    {
        currentState = State.Chase;
        if (!chaseLight.activeSelf)
        {
            chaseLight.SetActive(true);
            chaseLight.GetComponent<Animation>().Play();
            DOTween.To(() => currentLight, x => currentLight = x, 100, .5f);

        }

    }
    private float currentLight = 0;
    private float currentDrawer = 0;
    private void Update()
    {
        render.SetBlendShapeWeight(0, currentLight);
        render.SetBlendShapeWeight(1, currentDrawer);
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
    private void OpenDrawer()
    {
        currentState = State.Idle;
        DOTween.To(() => currentDrawer, x => currentDrawer = x, 100, .5f);
    }
    public void ResetPolice()
    {
        SpawnManager.Instance.RemovedPolice();
        transform.DOMove(transform.position + (transform.up * 30), leaveAnimTime).SetEase(leaveEase).OnComplete(() => Destroy(gameObject));
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
