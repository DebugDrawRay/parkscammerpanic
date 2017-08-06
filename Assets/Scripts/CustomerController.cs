using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class CustomerController : AiController
{
    public Transform itemContainer;
    private GameObject currentItem;
    [Header("Values")]
    public TextMeshPro dollarSign;
    public Color negativeColor = Color.red;
    public Color neutralColor = Color.yellow;
    public Color positiveColor = Color.green;
    public float signAnimationTime = .25f;
    public int signVibrato = 10;
    public float signElastic = 1;

    private float lastValue;
    private Tween signTween;

    public float itemGetTime;
    public Ease itemGetEase;

    public float timeToLeave = 15f;
    public float leaveAnimTime;
    public Ease leaveEase;

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
    }

    private void Update()
    {
        if (currentState == State.Active)
        {
            UpdateWander();
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Leave()
    {
        if (hasItem)
        {
            StartCoroutine(Leave_Coroutine());
        }
    }
    IEnumerator Leave_Coroutine()
    {
        yield return new WaitForSeconds(timeToLeave);
        currentState = State.Idle;
        Destroy(agent);
        Destroy(GetComponent<Rigidbody>());
        transform.DOMove(transform.position + (transform.up * 30), leaveAnimTime).SetEase(leaveEase).OnComplete(() => Destroy(gameObject));
    }
    public void GiveItem(GameObject item)
    {
        currentItem = item;
        currentItem.transform.SetParent(null);
        currentItem.layer = 0;
        currentItem.transform.DOMove(itemContainer.position, itemGetTime).SetEase(itemGetEase).OnComplete(() => { currentItem.transform.position = itemContainer.position; currentItem.transform.SetParent(itemContainer); Leave(); });
        SpawnManager.Instance.RemovedCustomer();
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
    public void UpdateDollarSign(float value)
    {
        if (value != lastValue)
        {
            if (signTween != null)
            {
                signTween.Kill(true);
                signTween = null;
            }
            signTween = dollarSign.transform.DOPunchPosition(transform.up, signAnimationTime, signVibrato, signElastic);
            lastValue = value;
        }
        float scale = value / 10;
        Color baseCol = neutralColor;
        Color targetCol = positiveColor;
        if (scale > 0)
        {
            targetCol = positiveColor;
        }
        else
        {
            targetCol = negativeColor;
        }
        dollarSign.color = Color.Lerp(baseCol, targetCol, Mathf.Abs(scale));
    }
}
