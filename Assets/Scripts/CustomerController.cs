using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : AiController
{
    public Transform itemContainer;
    private GameObject currentItem;

    public bool hasItem
    {
        get
        {
            return currentItem != null;
        }
    }

    public enum State
    {
        None,
        Idle,
        Active,
        Attentive
    }
    private State previousState = State.None;
    private State _currentState;
    public State currentState
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
    }

    private void OnDisable()
    {
        GameManager.GameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        Initialize();
        currentState = State.Idle;
    }

    private void Update()
    {
        if (currentState == State.Active)
        {
            UpdateWander();
            Leave();
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Leave()
	{
		if(hasItem && !Utils.IsVisibleFrom(GetComponentInChildren<Renderer>(), Camera.main))
        {
            Destroy(gameObject);
        }
	}
    public void GiveItem(GameObject item)
    {
        currentItem = item;
		currentItem.layer = 0;
        currentItem.transform.position = itemContainer.position;
        currentItem.transform.SetParent(itemContainer);
    }

    private void OnGameStateChanged(GameState gameState)
    {
        Debug.Log("Customer : State Change");
        switch (gameState)
        {
            case GameState.Paused:
                currentState = State.Idle;
                break;
            case GameState.Playing:
                currentState = previousState == State.None ? State.Active : previousState;
                break;
            default:
                currentState = State.Idle;
                break;
        }
    }
}
